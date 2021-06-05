using PipServices3.Commons.Refer;
using PipServices3.Components.Build;
namespace Monitoring {
  public class MonitoringServiceFactory : Factory {
    public static Descriptor Descriptor = new Descriptor("monitoring", "factory", "service", "default", "1.0");
    public static Descriptor ControllerDescriptor = new Descriptor("monitoring", "controller", "default", "*", "1.0");
    public static Descriptor RestServiceDescriptor = new Descriptor("monitoring", "service", "http", "*", "1.0");
    public MonitoringServiceFactory(){            
        RegisterAsType(ControllerDescriptor, typeof(MonitoringController));            
        RegisterAsType(RestServiceDescriptor, typeof(MonitoringRestService));        
    }    
  }
}