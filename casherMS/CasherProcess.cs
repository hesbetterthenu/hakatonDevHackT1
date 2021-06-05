using PipServices3.Container;
using PipServices3.Rpc.Build; 
namespace Casher {    
  public class CasherProcess : ProcessContainer {        
     public CasherProcess(): base("casher", "Casher microservice") {            
      _configPath = "config.yml";
      _factories.Add(new DefaultRpcFactory());            
      _factories.Add(new CasherServiceFactory());        
    }    
  }
}