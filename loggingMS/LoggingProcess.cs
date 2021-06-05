using PipServices3.Container;
using PipServices3.Rpc.Build; 
namespace Logging {    
  public class LoggingProcess : ProcessContainer {        
     public LoggingProcess(): base("logging", "Logging microservice") {            
      _configPath = "config.yml";
      _factories.Add(new DefaultRpcFactory());            
      _factories.Add(new LoggingServiceFactory());        
    }    
  }
}