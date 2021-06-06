using Microsoft.Extensions.Primitives;
using PipServices3.Commons.Refer;
using PipServices3.Rpc.Services;
using System.Linq; 
namespace Statistics {    
  public class StatisticsRestService : RestService {        
    private StatisticsController _controller;        
    public StatisticsRestService() {            
      _baseRoute = "statistics";            
      _dependencyResolver.Put("controller", new Descriptor("statistics", "controller", "default", "*", "1.0"));        
    }         
    public override void SetReferences(IReferences references) {            
      base.SetReferences(references);            
      _controller = _dependencyResolver.GetOneRequired<StatisticsController>("controller");        
    }         
    public override void Register() {            
      base.Register();            
      RegisterRoute("GET", "/isallive", async (request, response, routeData) => {                
        await SendResultAsync(response, await _controller.IsAlive());
      });     


    



    }    
  }
}