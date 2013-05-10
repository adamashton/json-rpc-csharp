JSON RPC 2.0 Client
===================

A lightweight implementation of Json RPC 2.0 in C# utilising the very good Json.NET from http://json.codeplex.com/

Example
=======
    using JsonRPC;
    using Newtonsoft.Json.Linq;
    
    ...  

    using (Client rpcClient = new Client("https://beta-api.betfair.com/json-rpc"))
    {
        rpcClient.Headers.Add("X-Application", "MyApplicationKey");
        
        Request request = rpcClient.NewRequest("SportsAPING/v1.0/listMarketBook");
        Response response = rpcClient.Rpc(request);
        
        if (response.Error != null)
        {
            JToken result = response.Result
        }
        else
        {
            Console.WriteLine(string.Format("Error in response, code:{0} message:{1}",
                result.Error.Code, result.Error.Message);
        }
    }

Installing
==========
Clone the repository and open in Visual Studio / Visual Express (> .NET 4.0). 
You should be able to build the project and then reference the JsonRPC.dll
This version is currently using .NET 4.0 of Json.NET
