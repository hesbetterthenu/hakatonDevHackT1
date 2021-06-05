using System.Threading.Tasks;
using PipServices3.Commons.Config;
using msIntereface;
namespace Operations {
  public class OperationsController : IConfigurable {
    private MsIntereface IMs = null;
    private string _defaultName = null;
    public void Configure(ConfigParams config){
      _defaultName = config.GetAsStringWithDefault("default_name", null);
      IMs = new MsApi();
    }
    public async Task<string> IsAlive() {
      return await IMs.IsAlive();
    }
  }
}