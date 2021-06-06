using System.Threading.Tasks;
using PipServices3.Commons.Config;
using msIntereface;
using System.Text.Json;
using System.Text.Json.Serialization;
namespace Operations {
  public class OperationsController : IConfigurable {
    private MsIntereface IMs = null;
    private string _defaultName = null;
    public void Configure(ConfigParams config){
      _defaultName = config.GetAsStringWithDefault("default_name", null);
      IMs = new MsApi();
    }
    public async Task<string> GetUser(int userId) {
      var res = IMs.getUser(userId);
      return await Task.FromResult(JsonSerializer.Serialize(res.Result));
    }
    public async Task<string> IsAlive() {
      return await IMs.IsAlive();
    }
    public async Task<string> deleteteHistoryCount(int id ,  int hystoryCount)
    {
      int  h= 0 ; 

      return await Task.FromResult(JsonSerializer.Serialize(h));
    }
// OperationMeta
  public async Task<string> type( int  type_id )
    {
     OperationMeta m = new OperationMeta ();

      return await Task.FromResult(JsonSerializer.Serialize(m));
    }

      public async Task<string>  operation (string json)
    {
   // JsonSerializer.Deserialize<OperationMeta>(json);

      return await Task.FromResult("");
    }


    
    //    public async Task<string>  getHistoryCount(int id  , int count )
    // {
    //   OperationMeta m = new OperationMeta () ; 
    //  auto  res = JsonSerializer.Serialize(m);

    //   return await Task.FromResult(res);
    // }



  }
}