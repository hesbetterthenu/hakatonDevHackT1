using PipServices3.Container;
using PipServices3.Rpc.Build; 
namespace Operations {    
  public class OperationsProcess : ProcessContainer {        
     public OperationsProcess(): base("operations", "Operations microservice") {            
      _configPath = "config.yml";
      _factories.Add(new DefaultRpcFactory());            
      _factories.Add(new OperationsServiceFactory());        
    }    
  }
}