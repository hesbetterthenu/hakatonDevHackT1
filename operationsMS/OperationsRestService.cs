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
      RegisterRoute("GET", "/getUser", async (request, response, routeData) => {     
        string ids = null;                
        if (request.Query.TryGetValue("id", out StringValues values)) {                    
          ids = values.FirstOrDefault();                
        }         
        int userId = int.Parse(ids);           
        await SendResultAsync(response, await _controller.GetUser(userId));
      });        
    }    
  }
}