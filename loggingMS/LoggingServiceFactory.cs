using PipServices3.Commons.Refer;
using PipServices3.Components.Build;
namespace Logging {
  public class LoggingServiceFactory : Factory {
    public static Descriptor Descriptor = new Descriptor("logging", "factory", "service", "default", "1.0");
    public static Descriptor ControllerDescriptor = new Descriptor("logging", "controller", "default", "*", "1.0");
    public static Descriptor RestServiceDescriptor = new Descriptor("logging", "service", "http", "*", "1.0");
    public LoggingServiceFactory(){            
        RegisterAsType(ControllerDescriptor, typeof(LoggingController));            
        RegisterAsType(RestServiceDescriptor, typeof(LoggingRestService));        
    }    
  }
}