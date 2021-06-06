using Microsoft.Extensions.Primitives;
using PipServices3.Commons.Refer;
using PipServices3.Rpc.Services;
using System.Linq; 
namespace Monitoring {    
  public class MonitoringRestService : RestService {        
    private MonitoringController _controller;        
    public MonitoringRestService() {            
      _baseRoute = "monitoring";            
      _dependencyResolver.Put("controller", new Descriptor("monitoring", "controller", "default", "*", "1.0"));        
    }         
    public override void SetReferences(IReferences references) {            
      base.SetReferences(references);            
      _controller = _dependencyResolver.GetOneRequired<MonitoringController>("controller");        
    }         
    public override void Register() {            
      base.Register();            
      RegisterRoute("GET", "/isallive", async (request, response, routeData) => {                
        await SendResultAsync(response, await _controller.IsAlive());
      });     


      RegisterRoute("GET", "/getsome", async (request, response, routeData) => {                
        string count_str = null;         
        string  from_str =  null ;       
        // request.Body
        if (request.Query.TryGetValue("count", out StringValues values1)) {                    
          count_str = values1.FirstOrDefault();                
        }     
        if (request.Query.TryGetValue("from", out StringValues values)) {                    
          from_str = values.FirstOrDefault();                
        }      
        int count = int.Parse(count_str);
        int from  =  int.Parse(from_str);
        response.ContentType = "json";
        await SendResultAsync(response, await _controller.getSome(from ,  count ));
      });


    }    
  }
}