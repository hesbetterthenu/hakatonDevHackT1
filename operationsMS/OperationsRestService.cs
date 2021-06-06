using Microsoft.Extensions.Primitives;
using PipServices3.Commons.Refer;
using PipServices3.Rpc.Services;
using System.Linq; 
namespace Operations {    
  public class OperationsRestService : RestService {        
    private OperationsController _controller;        
    public OperationsRestService() {            
      _baseRoute = "operations";            
      _dependencyResolver.Put("controller", new Descriptor("operations", "controller", "default", "*", "1.0"));        
    }         
    public override void SetReferences(IReferences references) {            
      base.SetReferences(references);            
      _controller = _dependencyResolver.GetOneRequired<OperationsController>("controller");        
    }         
    public override void Register() {            
      base.Register();            
      RegisterRoute("GET", "/isalive", async (request, response, routeData) => {                
        await SendResultAsync(response, await _controller.IsAlive());
      });        
      RegisterRoute("DELETE", "/operationhistory", async (request, response, routeData) => {     
        string ids = null;   
        string  historyCounts = null ;           
        if (request.Query.TryGetValue("id", out StringValues values1)) {                    
          ids = values1.FirstOrDefault();                
        }   
        if (request.Query.TryGetValue("historyCount", out StringValues values)) {                    
          historyCounts = values.FirstOrDefault();                
        }        
        int id = int.Parse(ids);  
        int count = int.Parse(historyCounts);          
        await SendResultAsync(response, await _controller.deleteteHistoryCount(id , count));
      });  


           
      RegisterRoute("GET", "/operationhistory", async (request, response, routeData) => {     
        string ids = null;   
        string  historyCounts = null ;           
        if (request.Query.TryGetValue("id", out StringValues values1)) {                    
          ids = values1.FirstOrDefault();                
        }   
        if (request.Query.TryGetValue("historyCount", out StringValues values)) {                    
          historyCounts = values.FirstOrDefault();                
        }        
        int id = int.Parse(ids);  
        int count = int.Parse(historyCounts);          
        await SendResultAsync(response, await _controller.getHistoryCount(id , count));
      });        
      



        RegisterRoute("GET", "/operation", async (request, response, routeData) => {     
        string types = null;                
        if (request.Query.TryGetValue("type", out StringValues values)) {                    
          types = values.FirstOrDefault();                
        }         
        int type = int.Parse(types);           
        await SendResultAsync(response, await _controller.type(type));
      });   



       RegisterRoute("POST", "/operation", async (request, response, routeData) => {     
        
          // request.Body
        await SendResultAsync(response, await _controller.operation(" d"));
      });   


    }    
  }
}