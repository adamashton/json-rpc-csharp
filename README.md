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
        GenericResponse response = rpcClient.Rpc(request);
        
        if (response.Result != null)
        {
            JToken result = response.Result;
        }
        else
            Console.WriteLine(string.Format("Error in response, code:{0} message:{1}",
                response.Error.Code, response.Error.Message);
                
                
        // Example with positional parameters
        JArray parameters = JArray.Parse(@"['Small', 'Medium', 'Large' ]");
        Request resuestWithPostionalParameters = rpcClient.NewRequest("SportsAPING/v1.0/listMarketBook", parameters);
        
        // Example with named parameters
        JObject namedParameters = JObject.Parse(@"{ CPU: 'Intel', }");
        Request resuestWithNamedParameters = rpcClient.NewRequest("SportsAPING/v1.0/listMarketBook", namedParameters);
    }
    
    
    

Installation 
============
Download and install Json.NET from http://json.codeplex.com/

Clone the repository and open in Visual Studio / Visual Express (> .NET 4.0)

Update the reference for Newtonsoft.Json to point to the correct Newtonsoft.Json.dll

You should be able to build the project and then reference the JsonRPC.dll

