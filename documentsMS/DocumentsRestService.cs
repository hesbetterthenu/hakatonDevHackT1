using Microsoft.Extensions.Primitives;
using PipServices3.Commons.Refer;
using PipServices3.Rpc.Services;
using System.Linq; 
namespace Documents {    
  public class DocumentsRestService : RestService {        
    private DocumentsController _controller;        
    public DocumentsRestService() {            
      _baseRoute = "documents";            
      _dependencyResolver.Put("controller", new Descriptor("documents", "controller", "default", "*", "1.0"));        
    }         
    public override void SetReferences(IReferences references) {            
      base.SetReferences(references);            
      _controller = _dependencyResolver.GetOneRequired<DocumentsController>("controller");        
    }         
    public override void Register() {            
      base.Register();            
      RegisterRoute("GET", "/isallive", async (request, response, routeData) => {                
        await SendResultAsync(response, await _controller.IsAlive());
      });        
    }    
  }
}