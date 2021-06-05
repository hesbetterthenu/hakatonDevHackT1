using PipServices3.Commons.Refer;
using PipServices3.Components.Build;
namespace Users {
  public class UsersServiceFactory : Factory {
    public static Descriptor Descriptor = new Descriptor("users", "factory", "service", "default", "1.0");
    public static Descriptor ControllerDescriptor = new Descriptor("users", "controller", "default", "*", "1.0");
    public static Descriptor RestServiceDescriptor = new Descriptor("users", "service", "http", "*", "1.0");
    public UsersServiceFactory(){            
        RegisterAsType(ControllerDescriptor, typeof(UsersController));            
        RegisterAsType(RestServiceDescriptor, typeof(UsersRestService));        
    }    
  }
}