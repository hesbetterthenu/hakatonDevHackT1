using PipServices3.Commons.Refer;
using PipServices3.Components.Build;
namespace Casher {
  public class CasherServiceFactory : Factory {
    public static Descriptor Descriptor = new Descriptor("casher", "factory", "service", "default", "1.0");
    public static Descriptor ControllerDescriptor = new Descriptor("casher", "controller", "default", "*", "1.0");
    public static Descriptor RestServiceDescriptor = new Descriptor("casher", "service", "http", "*", "1.0");
    public CasherServiceFactory(){            
        RegisterAsType(ControllerDescriptor, typeof(CasherController));            
        RegisterAsType(RestServiceDescriptor, typeof(CasherRestService));        
    }    
  }
}