# Installation

<pre>dotnet add package tada.SDK --version 0.0.1</pre>

# Configuration

Add the following settings to your appsettings.json:
```json
{
  "AzureAd": {
    "Instance": "https://login.microsoftonline.com/",
    "Domain": "duijvelshoff.com",
  },
  "tadaSDK": {
    "Services": {
      "Aggregation" : {
        "BaseUrl": "https://bunq.tada.red",
        "AppId": "a8897961-dfea-4efe-bcde-894ab59ad88a"
      }
    },
    "Application" : {
      "ClientId": "",
      "ClientSecret": ""
    },
    "Credentials" :  {
      "UserName" : "",
      "Password": ""
    }
  }
}
```
