import requests
import json
import pandas as pd
import csv
import numpy as np
import pymongo
import schedule

from sklearn.linear_model import LinearRegression
from sklearn.model_selection import train_test_split
from requests.auth import HTTPBasicAuth
from datetime import datetime
from sys import path
from pymongo import MongoClient
from datetime import timedelta

api = "https://api.leanheat.fi/v2/apartments/rawData?site_name=lh_lysholtalle11a_vejle&data=apt_temperature&start_time=1559347200"
key = "GZXXOHQ90LJSJDBKUC19R0QYFW*************************************************"

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
    #%Y-%m-%d
    data = [datetime.utcfromtimestamp(d).strftime('%H:%M') for d in data]

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
#print("Everthing was saved!")


#==========================================================================================#

#Get and show the data
#Store the data
df = pd.read_csv('leantimetemp.csv')
#Show the data
#print(df)

#Create a variable for predicting 'n' days out into the futre
projection = 10
#Create a new column called prediction
df['Prediction'] = df[['Temp']].shift(-projection)
#Show the data set
#print(df)

#Create the independent data set (X)
X = np.array(df[['Temp']])
#Remove the last 'n' rows
X = X[:-projection]
#print(X)

#Create the dependent data set (y)
y = df['Prediction'].values
y = y[:-projection]
#print(y)


#Split the data into % training and % testing data set
x_train, x_test, y_train, y_test = train_test_split(X,y, test_size= .10)

#Create and train the model
linReg = LinearRegression()
#Train the model
linReg.fit(x_train, y_train)

#Test the model using score. Closer to 1 the better
linReg_confidence = linReg.score(x_test, y_test)
print('Linear Regression Confidence', linReg_confidence)

#Create a variable called x_projection and set it equal to the last 14 rows of data from the original data set
x_projection = np.array(df[['Temp']])[-projection:]
#print(x_projection)

#Print the linear regression models predictions for the next 'n' days
linReg_prediction = linReg.predict(x_projection)
#print('Prediction for the next n days:',linReg_prediction)

#==========================================================================================#

now = datetime.now()
# new = datetime.now()
# new += timedelta(hours=2.6)
#Create a CSV file with a column name and saves the data in it
df = pd.DataFrame(columns=['Predicted_temp','Datetime']) # Create Columns

df['Predicted_temp'] = np.around(linReg_prediction, decimals=1) # Add Predicted Temp
#df['Date'] = now.strftime('%d-%m-%Y') # Populate Date Column
#df['Time'] = new.strftime('%H:%M')



lastTime = now.strftime('%d-%m-%Y %H:%M') # Hours and Minutes

for index, items in df.iterrows():
    #print("!!!!", items[2])
    df['Datetime'][index] = (datetime.strptime(lastTime, '%d-%m-%Y %H:%M') + timedelta(hours=2.4)).strftime('%d-%m-%Y %H:%M')
    lastTime = df['Datetime'][index]
    

#df['Time'] = now.strftime('%H:%M')
df.to_csv('Predicted_data.csv', index=False)
 
df = pd.read_csv('Predicted_data.csv')

#==========================================================================================#

class MongoDB(object):

    def __init__(self, dBName=None, collectionName=None):
        self.dBname = dBName
        self.collectionName = collectionName

        self.client = MongoClient('mongodb+srv://Admin:Admin@projekt.j0lzw.mongodb.net/test')

        self.DB = self.client[self.dBname]
        self.collection = self.DB[self.collectionName]


    def InsertData(self, path=None):
        
        df = pd.read_csv(path) 
        data = df.to_dict('records')
        
        self.collection.insert_many(data, ordered=False)
        print('All the data has been exported to mongoDB')



if __name__ == "__main__":
    mongodb = MongoDB(dBName= 'Tempdata', collectionName='Data')
    mongodb.InsertData(path='Predicted_data.csv')



#==========================================================================================#

class MongoDB(object):

    def __init__(self, dBName=None, collectionName=None):
        self.dBname = dBName
        self.collectionName = collectionName

        self.client = MongoClient('mongodb+srv://Admin:Admin@projekt.j0lzw.mongodb.net/test')

        self.DB = self.client[self.dBname]
        self.collection = self.DB[self.collectionName]


    def InsertData(self, path=None):
        
        df = pd.read_csv(path) 
        data = df.to_dict('records')
        
        self.collection.insert_many(data, ordered=False)
        print('All the data has been exported to mongoDB')



if __name__ == "__main__":
    mongodb = MongoDB(dBName= 'LeanheatSearch', collectionName='SearchData')
    mongodb.InsertData(path='Predicted_data.csv')

print('Done!')
