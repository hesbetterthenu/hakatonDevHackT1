using PipServices3.Container;
using PipServices3.Rpc.Build; 
namespace Monitoring {    
  public class MonitoringProcess : ProcessContainer {        
     public MonitoringProcess(): base("monitoring", "Monitoring microservice") {            
      _configPath = "config.yml";
      _factories.Add(new DefaultRpcFactory());            
      _factories.Add(new MonitoringServiceFactory());        
    }    
  }
}