import requests
from requests.auth import HTTPBasicAuth
import json
from datetime import datetime

api = "https://api.leanheat.fi/v2/apartments/rawData?site_name=lh_lysholtalle11a_vejle&data=apt_temperature&start_time=1559347200"


leanheat_temp = []
leanheat_time = []

#API
response = requests.get('https://api.leanheat.fi/v2/sites/metadata')

if response.status_code == 401:    
    response = requests.get(api, auth=HTTPBasicAuth('dandy-leanheat-api-key', 'GZXXOHQ90LJSJDBKUC19R0QYFWOAUX67KZZGLK5UOPPA0EG3MCNT9TQEOIEEDPJ1TR88BBWHEMLCCNRL7CCCZFRUOSZN9HIAG078Y3254NP44XL6NELAKYN7UMXO47DI'))
    with open("projektleanheatapi.json", "w") as f:
        f.write(response.text)

#Open the json file
with open("projektleanheatapi.json") as f:
    data = json.load(f)

#Remove all the unnecessary stuff. Could be removed in the future!
for temp in data:
    del temp['series_id']
    del temp['series_loc']
    del temp['location_id']
    del temp['location_alias']
    del temp['data_version']

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



print("Everthing was saved!")