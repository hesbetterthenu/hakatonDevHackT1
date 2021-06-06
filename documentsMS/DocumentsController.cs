using System.Threading.Tasks;
using PipServices3.Commons.Config;
using msIntereface;
using System.Text.Json;
using System.Text.Json.Serialization;
namespace Documents {
  public class DocumentsController : IConfigurable {
    private string _defaultName = null;
    private MsIntereface IMs = null;
    public void Configure(ConfigParams config){
      _defaultName = config.GetAsStringWithDefault("default_name", null);
      IMs = new MsApi();
    }
    public async Task<string> IsAlive()        {
      return await IMs.IsAlive();
    }    

      public async Task<string> id (int ids)  {

        DocumentMeta m = new DocumentMeta() ; 
        return await Task.FromResult(JsonSerializer.Serialize(m));
      //return await IMs.doc_ids(int ids);
    }   
  }
}