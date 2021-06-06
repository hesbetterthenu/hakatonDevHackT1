using Microsoft.Extensions.Primitives;
using PipServices3.Commons.Refer;
using PipServices3.Rpc.Services;
using System.Linq; 
namespace Casher {    
  public class CasherRestService : RestService {        
    private CasherController _controller;        
    public CasherRestService() {            
      _baseRoute = "casher";            
      _dependencyResolver.Put("controller", new Descriptor("casher", "controller", "default", "*", "1.0"));        
    }         
    public override void SetReferences(IReferences references) {            
      base.SetReferences(references);            
      _controller = _dependencyResolver.GetOneRequired<CasherController>("controller");        
    }         
    public override void Register() {            
      base.Register();            
      RegisterRoute("GET", "/isallive", async (request, response, routeData) => {                
        await SendResultAsync(response, await _controller.IsAlive());
      });  


        RegisterRoute("POST", "/deposit", async (request, response, routeData) => {     
        string accountIdStr = null;        
        string amountStr = null;            
        if (request.Query.TryGetValue("account_id", out StringValues values1)) {                    
          accountIdStr = values1.FirstOrDefault();                
        }      
          if (request.Query.TryGetValue("amount", out StringValues values)) {                    
          amountStr = values.FirstOrDefault();                
        }      
        int amount = int.Parse(amountStr);      
         int accountID = int.Parse(accountIdStr);      
        await SendResultAsync(response, await _controller.get_status(accountID, amount));
      });   

        RegisterRoute("GET", "/getCashFlows", async (request, response, routeData) => {     
        string userIdStr = null;         
        if (request.Query.TryGetValue("user_id", out StringValues values1)) {                    
          userIdStr = values1.FirstOrDefault();                
        }      
        int userId = int.Parse(userIdStr);      
        await SendResultAsync(response, await _controller.get_accounts(userId));
      });   

      
    }    
  }
}