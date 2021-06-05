using PipServices3.Commons.Refer;
using PipServices3.Components.Build;
namespace Operations {
  public class OperationsServiceFactory : Factory {
    public static Descriptor Descriptor = new Descriptor("operations", "factory", "service", "default", "1.0");
    public static Descriptor ControllerDescriptor = new Descriptor("operations", "controller", "default", "*", "1.0");
    public static Descriptor RestServiceDescriptor = new Descriptor("operations", "service", "http", "*", "1.0");
    public OperationsServiceFactory(){            
        RegisterAsType(ControllerDescriptor, typeof(OperationsController));   
        RegisterAsType(RestServiceDescriptor, typeof(OperationsRestService));
    }    
  }
}