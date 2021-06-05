using System;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace msIntereface
{
    static class Globals
    {
        public static string users_ms_ip = System.Environment.GetEnvironmentVariable("users_ms_ip");
        public static string users_ms_port = System.Environment.GetEnvironmentVariable("users_ms_port");
        public static string statistics_ms_ip = System.Environment.GetEnvironmentVariable("statistics_ms_ip");
        public static string statistics_ms_port = System.Environment.GetEnvironmentVariable("statistics_ms_port");
        public static string operations_ms_ip = System.Environment.GetEnvironmentVariable("operations_ms_ip");
        public static string operations_ms_port = System.Environment.GetEnvironmentVariable("operations_ms_port");
        public static string monitoring_ms_ip = System.Environment.GetEnvironmentVariable("monitoring_ms_ip");
        public static string monitoring_ms_port = System.Environment.GetEnvironmentVariable("monitoring_ms_port");
        public static string logging_ms_ip = System.Environment.GetEnvironmentVariable("logging_ms_ip");
        public static string logging_ms_port = System.Environment.GetEnvironmentVariable("logging_ms_port");
        public static string documents_ms_ip = System.Environment.GetEnvironmentVariable("documents_ms_ip");
        public static string documents_ms_port = System.Environment.GetEnvironmentVariable("documents_ms_port");
        public static string casher_ms_ip = System.Environment.GetEnvironmentVariable("casher_ms_ip");
        public static string casher_ms_port = System.Environment.GetEnvironmentVariable("casher_ms_port");
        public static string bd_addr = System.Environment.GetEnvironmentVariable("bd_addr");
        public static string bd_log = System.Environment.GetEnvironmentVariable("bd_log");
        public static string bd_pass = System.Environment.GetEnvironmentVariable("bd_pass");
    }

    public interface MsIntereface {
        Task<string> IsAlive();
        Task<string> getMonitor();
        Task<UserMeta> getUser(int userId);
    }
    public class MsApi : MsIntereface
    {
        public async Task<UserMeta> getUser(int userId) {            
            string html = string.Empty;
            string url = $"http://localhost:8082/users/user?id={userId}";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
            using(HttpWebResponse response = (HttpWebResponse)await request.GetResponseAsync())
            using(Stream stream = response.GetResponseStream())
            using(StreamReader reader = new StreamReader(stream))
            {
                var temp = reader.ReadToEnd();
                temp = temp.Replace("\\", "");
                temp = temp.Substring(1, temp.Length-2);
                Console.WriteLine(temp);
                UserMeta res = JsonSerializer.Deserialize<UserMeta>(temp);
                return await Task.FromResult(res);
            }

        }
        public async Task<string> IsAlive() {
            return await Task.FromResult($"alive");
        }
        public async Task<string> getMonitor() {
            string html = string.Empty;
            string url = $"http://localhost:8081/monitoring/isallive";
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
