using PipServices3.Container;
using PipServices3.Rpc.Build; 
namespace Documents {    
  public class DocumentsProcess : ProcessContainer {        
     public DocumentsProcess(): base("documents", "Documents microservice") {            
      _configPath = "config.yml";
      _factories.Add(new DefaultRpcFactory());            
      _factories.Add(new DocumentsServiceFactory());        
    }    
  }
}