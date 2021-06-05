using PipServices3.Container;
using PipServices3.Rpc.Build; 
namespace Users {    
  public class UsersProcess : ProcessContainer {        
     public UsersProcess(): base("users", "Users microservice") {            
      _configPath = "config.yml";
      _factories.Add(new DefaultRpcFactory());            
      _factories.Add(new UsersServiceFactory());        
    }    
  }
}