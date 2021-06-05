using PipServices3.Commons.Refer;
using PipServices3.Components.Build;
namespace Statistics {
  public class StatisticsServiceFactory : Factory {
    public static Descriptor Descriptor = new Descriptor("statistics", "factory", "service", "default", "1.0");
    public static Descriptor ControllerDescriptor = new Descriptor("statistics", "controller", "default", "*", "1.0");
    public static Descriptor RestServiceDescriptor = new Descriptor("statistics", "service", "http", "*", "1.0");
    public StatisticsServiceFactory(){            
        RegisterAsType(ControllerDescriptor, typeof(StatisticsController));            
        RegisterAsType(RestServiceDescriptor, typeof(StatisticsRestService));        
    }    
  }
}