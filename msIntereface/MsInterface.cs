using System;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using Npgsql;
using System.Collections.Generic;

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
        public static string bd_ip = System.Environment.GetEnvironmentVariable("bd_ip");
        public static string bd_log = System.Environment.GetEnvironmentVariable("bd_log");
        public static string bd_pass = System.Environment.GetEnvironmentVariable("bd_pass");
    }

    public interface MsIntereface {
        Task<string> IsAlive();
        Task<string> getMonitor();
        Task<UserMeta> getUser(int userId);
        Task<List<AccountMeta>> getAccounts(int userId);
        Task<List<UserMeta>> getUsers(int first, int count);
        Task<Boolean> withdraw(int account_id, long amount);
        Task<Boolean> deposit(int account_id, long amount);
        Task<List<DocumentSignOperaation>> DeleteDocumentSignOperaationsJ(int op_id, int count);
        Task<List<DocumentSignOperaation>> GetDocumentSignOperaationsJ(int op_id, int count);
        Task<List<DocumentSignOperaation>> GetDocumentSignOperaations(int user_id);
        Task<List<DocumentSignOperaation>> DeleteCreditOperaationJ(int op_id, int count);
        Task<List<DocumentSignOperaation>> GetCreditOperaationJ(int op_id, int count);
        Task<List<DocumentSignOperaation>> GetCreditOperaation(int user_id);
        Task<List<DocumentSignOperaation>> DeleteTransactionOperaationJ(int op_id, int count);
        Task<List<DocumentSignOperaation>> GetTransactionOperaationJ(int op_id, int count);
        Task<List<DocumentSignOperaation>> GetTransactionOperaation(int account_id);
    }
    public class MsApi : MsIntereface
    {
        public async Task<List<AccountMeta>> getAccounts(int userId) {
            List<AccountMeta> res = new List<AccountMeta>();
            try
            {
                string connstring = String.Format("Server={0};Port={1};" + 
                    "User Id={2};Password={3};Database=dbname;",
                    Globals.bd_addr, Globals.bd_ip, Globals.bd_log, 
                    Globals.bd_pass);
                NpgsqlConnection conn = new NpgsqlConnection(connstring);
                conn.Open();

                using (var cmd = new NpgsqlCommand("select id, name, user_id, amount, frozen from accountmeta where user_id=" + userId, conn))
                using (var reader = cmd.ExecuteReader()) {
                    while(reader.Read()) {
                        AccountMeta temp = new AccountMeta();
                        temp.id = reader.GetInt32(0);
                        temp.name = reader.GetString(1);
                        temp.userId = reader.GetInt32(2);
                        temp.amount = reader.GetInt64(3);
                        temp.frozen = reader.GetInt64(4);
                        res.Add(temp);
                    }
                }
                conn.Close();
            }
            catch (Exception msg)
            {
                Console.WriteLine(msg);
                return await Task.FromResult(res);
            }
            return await Task.FromResult(res);
        }
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
