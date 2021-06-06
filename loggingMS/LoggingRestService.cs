using Microsoft.Extensions.Primitives;
using PipServices3.Commons.Refer;
using PipServices3.Rpc.Services;

using System.Text.Json;  //
using System.Text.Json.Serialization; //
using System.Linq; 
using System ; 
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


      
      RegisterRoute("GET", "/log", async (request, response, routeData) => {                     
      string body = request.Body
      // System.Console.WriteLine(request.Body);

       // string  login = JsonSerializer.Serialize(request.Body)["log"];
       // System.Console.WriteLine($"login : {login}"); 
   
        response.ContentType = "text";
        await SendResultAsync(response, await _controller.getResponse(body));
      });     
    }    
  }
}


      // RegisterRoute("GET", "/getsome", async (request, response, routeData) => {                
      //   string count_str = null;         
      //   string  from_str =  null ;       
      //   // request.Body
      //   if (request.Query.TryGetValue("count", out StringValues values1)) {                    
      //     count_str = values1.FirstOrDefault();                
      //   }     
      //   if (request.Query.TryGetValue("from", out StringValues values)) {                    
      //     from_str = values.FirstOrDefault();                
      //   }      
      //   int count = int.Parse(count_str);
      //   int from  =  int.Parse(from_str);
      //   response.ContentType = "json";
      //   await SendResultAsync(response, await _controller.getSome(from ,  count ));
      // });