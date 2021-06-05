using System;
using System.Threading.Tasks;
using PipServices3.Commons.Config;
using msIntereface;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Users {
  public class UsersController : IConfigurable {
    private string _defaultName = null;
    private MsIntereface IMs = null;
    public void Configure(ConfigParams config){
      _defaultName = config.GetAsStringWithDefault("default_name", null);
      IMs = new MsApi();
    }
    public async Task<string> getUser(int userId) {
      string res = "";
      UserMeta user = new UserMeta();
      user.id = userId;
      res = JsonSerializer.Serialize(user);
      return await Task.FromResult(res);
    }
    public async Task<string> IsAlive()        {
      return await IMs.IsAlive();
    }    
  }
}