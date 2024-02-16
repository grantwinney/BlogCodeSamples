import urllib2
import json
import datetime

def __call_api(endpoint):
    request = urllib2.Request('http://api.open-notify.org%s' %(endpoint))
    response = urllib2.urlopen(request)
    return json.loads(response.read())

def show_roster():
    result = __call_api('/astros.json')
    print "There are %d people in space:" % (result['number']),
    for i in range(result['number']):
        print result['people'][i]['name'] + ",",

def show_next_pass(latitude, longitude):
    result = __call_api('/iss-pass.json?lat=%s&lon=%s' %(latitude, longitude))
    print('The next ISS pass for %s %s is %s for %s seconds'
          %(result['request']['latitude'],
            result['request']['longitude'],
            datetime.datetime.fromtimestamp(result['response'][0]['risetime']),
            result['response'][0]['duration']))
