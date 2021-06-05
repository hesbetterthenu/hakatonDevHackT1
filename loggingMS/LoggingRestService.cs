using Microsoft.Extensions.Primitives;
using PipServices3.Commons.Refer;
using PipServices3.Rpc.Services;
using System.Linq; 
namespace Logging {    
  public class LoggingRestService : RestService {        
    private LoggingController _controller;        
    public LoggingRestService() {            
      _baseRoute = "logging";            
      _dependencyResolver.Put("controller", new Descriptor("logging", "controller", "default", "*", "1.0"));        
    }         
    public override void SetReferences(IReferences references) {            
      base.SetReferences(references);            
      _controller = _dependencyResolver.GetOneRequired<LoggingController>("controller");        
    }         
    public override void Register() {            
      base.Register();            
      RegisterRoute("GET", "/isallive", async (request, response, routeData) => {                
        await SendResultAsync(response, await _controller.IsAlive());
      });        
    }    
  }
}