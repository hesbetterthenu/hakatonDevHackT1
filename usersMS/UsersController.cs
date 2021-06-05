using System.Threading.Tasks;
using PipServices3.Commons.Config;
using msIntereface;
namespace Users {
  public class UsersController : IConfigurable {
    private string _defaultName = null;
    private MsIntereface IMs = null;
    public void Configure(ConfigParams config){
      _defaultName = config.GetAsStringWithDefault("default_name", null);
      IMs = new MsApi();
    }
    public async Task<string> IsAlive()        {
      return await IMs.IsAlive();
    }    
  }
}