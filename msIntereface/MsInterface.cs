using System;
using System.Threading.Tasks;
using System.Net;
using System.IO;

namespace msIntereface
{
    public interface MsIntereface {
        Task<string> IsAlive();
        Task<string> getMonitor();
    }
    public class MsApi : MsIntereface
    {
        public async Task<string> IsAlive() {
            return await Task.FromResult($"alive");
        }
        public async Task<string> getMonitor() {
            string html = string.Empty;
            string url = @"http://localhost:8081/monitoring/isallive";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

            using(HttpWebResponse response = (HttpWebResponse)await request.GetResponseAsync())
            using(Stream stream = response.GetResponseStream())
            using(StreamReader reader = new StreamReader(stream))
            {
                return await reader.ReadToEndAsync();
            }
        }

    }
}
