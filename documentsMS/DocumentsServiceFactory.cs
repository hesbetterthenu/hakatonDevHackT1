using PipServices3.Commons.Refer;
using PipServices3.Components.Build;
namespace Documents {
  public class DocumentsServiceFactory : Factory {
    public static Descriptor Descriptor = new Descriptor("documents", "factory", "service", "default", "1.0");
    public static Descriptor ControllerDescriptor = new Descriptor("documents", "controller", "default", "*", "1.0");
    public static Descriptor RestServiceDescriptor = new Descriptor("documents", "service", "http", "*", "1.0");
    public DocumentsServiceFactory(){            
        RegisterAsType(ControllerDescriptor, typeof(DocumentsController));            
        RegisterAsType(RestServiceDescriptor, typeof(DocumentsRestService));        
    }    
  }
}