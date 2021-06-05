using Microsoft.Extensions.Primitives;
using PipServices3.Commons.Refer;
using PipServices3.Rpc.Services;
using System.Linq; 
namespace Users {    
  public class UsersRestService : RestService {        
    private UsersController _controller;        
    public UsersRestService() {            
      _baseRoute = "users";            
      _dependencyResolver.Put("controller", new Descriptor("users", "controller", "default", "*", "1.0"));        
    }         
    public override void SetReferences(IReferences references) {            
      base.SetReferences(references);            
      _controller = _dependencyResolver.GetOneRequired<UsersController>("controller");        
    }         
    public override void Register() {            
      base.Register();            
      RegisterRoute("GET", "/isallive", async (request, response, routeData) => {                
        await SendResultAsync(response, await _controller.IsAlive());
      });        
      RegisterRoute("GET", "/user", async (request, response, routeData) => {                
        string ids = null;                
        if (request.Query.TryGetValue("id", out StringValues values)) {                    
          ids = values.FirstOrDefault();                
        }         
        int userId = int.Parse(ids);
        response.ContentType = "json";
        await SendResultAsync(response, await _controller.getUser(userId));
      });        
    }    
  }
}