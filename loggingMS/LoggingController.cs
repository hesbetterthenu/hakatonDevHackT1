using System.Threading.Tasks;
using PipServices3.Commons.Config;
using System.Text.Json;
using System.Text.Json.Serialization;
using msIntereface;
namespace Logging {
  public class LoggingController : IConfigurable {
    private string _defaultName = null;
    private MsIntereface IMs = null;
    public void Configure(ConfigParams config){
      _defaultName = config.GetAsStringWithDefault("default_name", null);
      IMs = new MsApi();
    }
    public async Task<string> IsAlive()        {
      return await IMs.IsAlive();
    }    

    public async Task <string> getResponse (string body)
    {
      return await Task.FromResult (body);
    }
  }
}