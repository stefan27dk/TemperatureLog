import requests
from requests.auth import HTTPBasicAuth
import json

#API
response = requests.get('https://api.leanheat.fi/v2/sites/metadata')

#Access the data in the api and puts its in a json file
if response.status_code == 401:    
    response = requests.get('https://api.leanheat.fi/v2/sites/aggregateData?site_name=lh_lysholtalle11a_vejle&data=apt_temperature&start_time=1559347200', auth=HTTPBasicAuth('dandy-leanheat-api-key', 'GZXXOHQ90LJSJDBKUC19R0QYFWOAUX67KZZGLK5UOPPA0EG3MCNT9TQEOIEEDPJ1TR88BBWHEMLCCNRL7CCCZFRUOSZN9HIAG078Y3254NP44XL6NELAKYN7UMXO47DI'))
    with open("leanheatapidata.json", "w") as f:
        f.write(response.text)
        print("json file saved!")

#Open the json file
with open("leanheatapidata.json") as f:
    data = json.load(f)


#Remove all the unnecessary stuff
for temp in data:
    del temp['series_id']
    del temp['series_loc']
    del temp['location_id']
    del temp['location_alias']
    del temp['data_version']


#Makes the json file more readable
with open("leanheatapidata.json", "w") as f:
    json.dump(data, f, indent=2)

#Saves it to a CSV file
with open('leanheatapidata.csv', 'w') as f:
    json.dump(data, f, indent=2)
    print("csv file saved!")
