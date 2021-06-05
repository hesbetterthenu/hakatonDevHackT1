using PipServices3.Container;
using PipServices3.Rpc.Build; 
namespace Statistics {    
  public class StatisticsProcess : ProcessContainer {        
     public StatisticsProcess(): base("statistics", "Statistics microservice") {            
      _configPath = "config.yml";
      _factories.Add(new DefaultRpcFactory());            
      _factories.Add(new StatisticsServiceFactory());        
    }    
  }
}