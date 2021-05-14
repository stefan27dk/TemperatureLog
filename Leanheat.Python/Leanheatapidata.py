import requests
import json
import pandas as pd
import csv

from requests.auth import HTTPBasicAuth
from datetime import datetime


api = "https://api.leanheat.fi/v2/apartments/rawData?site_name=lh_lysholtalle11a_vejle&data=apt_temperature&start_time=1559347200"
key = "GZXXOHQ90LJSJDBKUC19R0QYFWOAUX67KZZGLK5UOPPA0EG3MCNT9TQEOIEEDPJ1TR88BBWHEMLCCNRL7CCCZFRUOSZN9HIAG078Y3254NP44XL6NELAKYN7UMXO47DI"

leanheat_temp = []
leanheat_time = []

#API
response = requests.get('https://api.leanheat.fi/v2/sites/metadata')

if response.status_code == 401:    
    response = requests.get(api, auth=HTTPBasicAuth('dandy-leanheat-api-key', key))
    with open("projektleanheatapi.json", "w") as f:
        f.write(response.text)

#Open the json file
with open("projektleanheatapi.json") as f:
    data = json.load(f)

#Remove all the unnecessary stuff. Could be removed in the future!
#for temp in data:
    #del temp['series_id']
    #del temp['series_loc']
    #del temp['location_id']
    #del temp['location_alias']
    #del temp['data_version']

#Open the file in json, and save it again to be more readable
with open("projektleanheatapi.json", "w") as f:
    json.dump(data, f, indent=2,)

#Goes sorts everything in temp and time
with open('projektleanheatapi.json') as json_file:
    data = json.load(json_file)
    for i in data:
      for k in i['data']:
        leanheat_temp.append(k[1])
        leanheat_time.append(k[0])

with open('leantemp.json', 'w') as f:
    json.dump(leanheat_temp, f, indent=2)

with open('leantime.json', 'w') as f:
    json.dump(leanheat_time, f, indent=2)

#Convert unixtimestamp to datetime
with open('leantime.json') as f:
    data = json.load(f)
    data = [datetime.utcfromtimestamp(d).strftime('%Y-%m-%d %H:%M:%S') for d in data]

with open('leantime.json', 'w') as f:
    json.dump(data, f, indent=2)

#==========================================================================================#


#1 Date -------------------------------
with open('leantime.json','r') as time:
    timeData = json.load(time)

#2 Temp----------------------------------
with open('leantemp.json', 'r') as date:
    tempData = json.load(date)

df = pd.DataFrame(columns=['Date','Temp'])

df["Date"] = timeData
df["Temp"] = tempData

#2 Combined File ----------------------------------
df.to_csv('leantimetemp.csv',index=False)

#print(df)
print("Everthing was saved!")


#==========================================================================================#

import numpy as np
import pandas as pd
from sklearn.tree import DecisionTreeRegressor
from sklearn.linear_model import LinearRegression
from sklearn.model_selection import train_test_split
import matplotlib.pyplot as plt
plt.style.use('bmh')

df = pd.read_csv('leantimetemp.csv')
df.head(6)

plt.figure(figsize=(16,8))
plt.title('Leanheat')
plt.xlabel('Time')
plt.ylabel('Temp')
plt.plot(df['Temp'])
#plt.show()

df = df[['Temp']]
df.head(4)


future = 10
df['Prediction'] = df[['Temp']].shift(-future)
df.tail(4)

X = np.array(df.drop(['Prediction'],1))[:-future]
#print(X)

y = np.array(df['Prediction'])[:-future]
#print(y)

#Training 75% and testing 25%
x_train, x_test, y_train, y_test = train_test_split(X,y, test_size= 0.25)

tree = DecisionTreeRegressor().fit(x_train, y_train)
lr = LinearRegression().fit(x_train, y_train)

x_future = df.drop(['Prediction'], 1)[:-future]
x_future = x_future.tail(future)
x_future = np.array(x_future)
x_future

tree_prediction = tree.predict(x_future)
#print(tree_prediction)
#print()
lr_prediction = lr.predict(x_future)
#print(lr_prediction)

predictions = tree_prediction

valid = df[X.shape[0]:]
valid['Predictions'] = predictions

plt.figure(figsize=(16,8))
plt.title('Model')
plt.xlabel('Days')
plt.ylabel('Temp')
plt.plot(df['Temp'])
plt.plot(valid[['Temp', 'Predictions']])
plt.legend(['Orignal', 'Validation', 'Prediction'])
#plt.show()

predictions = lr_prediction

valid = df[X.shape[0]:]
valid['Predictions'] = predictions


plt.figure(figsize=(16,8))
plt.title('Model')
plt.xlabel('Days')
plt.ylabel('Temp')
plt.plot(df['Temp'])
plt.plot(valid[['Temp', 'Predictions']])
plt.legend(['Orignal', 'Validation', 'Prediction'])
#plt.show()


print(tree_prediction)
#print(lr_prediction)

df = pd.DataFrame(columns=['Predicted Data'])

df['Predicted Data'] = tree_prediction

df.to_csv('Storeddata.csv', index=False)

df = pd.read_csv('Storeddata.csv')
df.head(6)

plt.figure(figsize=(16,8))
plt.title('Leanheat')
plt.xlabel('Time')
plt.ylabel('Temp')
plt.plot(df['Predicted Data'])
#plt.show()