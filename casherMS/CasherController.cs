using System.Threading.Tasks;
using PipServices3.Commons.Config;
using msIntereface;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Casher {
  public class StatusRet { 
    public bool status {get; set;}
  }
  public class CasherController : IConfigurable {
    private string _defaultName = null;
    private MsIntereface IMs = null;
    public void Configure(ConfigParams config){
      _defaultName = config.GetAsStringWithDefault("default_name", null);
      IMs = new MsApi();
    }
    public async Task<string> IsAlive()        {
      return await IMs.IsAlive();
    }    

      public async Task<string> get_status( int  account_id ,  int amount )        {
        StatusRet ret = new StatusRet();
        ret.status  =  false ; 

      return await  Task.FromResult (JsonSerializer.Serialize(ret))  ;  // IMs.IsAlive();
    }    

      public async Task<string> get_accounts( int  userId )        {
        return await  Task.FromResult (JsonSerializer.Serialize(await IMs.getAccounts(userId)))  ;  // IMs.IsAlive();
    }    
  }
}