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
        Task<List<CreditOperaation>> DeleteCreditOperaationJ(int op_id, int count);
        Task<List<CreditOperaation>> GetCreditOperaationJ(int op_id, int count);
        Task<List<CreditOperaation>> GetCreditOperaation(int user_id);
        Task<List<TransactionOperaation>> DeleteTransactionOperaationJ(int op_id, int count);
        Task<List<TransactionOperaation>> GetTransactionOperaationJ(int op_id, int count);
        Task<List<TransactionOperaation>> GetTransactionOperaation(int account_id);
        Task<DocumentSignOperaation> NewDocumentSignOperaation();
        Task<TransactionOperaation> NewTransactionOperaation();
        Task<CreditOperaation> NewCreditOperaation();
        Task<CreditOperaation> PostCreditOperaation(CreditOperaation op);
        Task<TransactionOperaation> PostTransactionOperaation(TransactionOperaation op);
        Task<DocumentSignOperaation> PostDocumentSignOperaation(DocumentSignOperaation op);

    }
    public class MsApi : MsIntereface
        Task<List<CreditOperaation>> DeleteCreditOperaationJ(int op_id, int count) {
        List<CreditOperaation> res = new List<CreditOperaation>();
        try
            {
                string connstring = String.Format("Server={0};Port={1};" + 
                    "User Id={2};Password={3};Database=dbname;",
                    Globals.bd_addr, Globals.bd_ip, Globals.bd_log, 
                    Globals.bd_pass);
                NpgsqlConnection conn = new NpgsqlConnection(connstring);
                conn.Open();

                using (var cmd = new NpgsqlCommand("select id from DocumentSignOperaation where id=" + op_id, conn))
                using (var reader = cmd.ExecuteReader()) {
                    while(reader.Read()) {
                        CreditOperaation temp = new CreditOperaation();
                        temp.id.GetInteger(0);
                        temp.type.GetInteger(1);
                        temp.status_id.GetInteger(2);
                        temp.whoAprovedUserId.GetInteger(3);
                        temp.created_dt.GetDataTime(4);
                        temp.edit_dt.GetDataTime(5);
                        temp.acount_id.GetInteger(6);
                        temp.period.GetDateTime(7);
                        temp.currency.GetString(8);
                        temp.amount.GetBigInteger(9);
                    }
                           using (var command = new NpgsqlCommand
                            ("DELETE FROM CreditOperaation WHERE id ( IN SELECT " 
                                + temp.id + " FROM CreditOperaation ORDER BY timestamp DESK LIMIT 10 )" ))
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



        Task<List<DocumentSignOperaation>> GetDocumentSignOperaations(int user_id) { 
        List<DocumentSignOperaation> res = new List<DocumentSignOperaation>();
            try
            {
                string connstring = String.Format("Server={0};Port={1};" + 
                    "User Id={2};Password={3};Database=dbname;",
                    Globals.bd_addr, Globals.bd_ip, Globals.bd_log, 
                    Globals.bd_pass);
                NpgsqlConnection conn = new NpgsqlConnection(connstring);
                conn.Open();

                using (var cmd = new NpgsqlCommand("select user_id from DocumentSignOperaation where user_id=" + user_id, conn))
                using (var reader = cmd.ExecuteReader()) {
                    while(reader.Read()) {
                        DocumentSignOperaation temp = new DocumentSignOperaation();
                        temp.user_id = reader.GetInt32(0);
                        temp.type = reader.GetInt32(1);
                        temp.status_id.GetInt32(2);
                        temp.whoAprovedUserId.GetInt32(3);
                        temp.created_dt.GetDateTime(4);
                        temp.edit_dt.GetDateTime(5);
                        temp.document_id.GetInt32(6)
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




        public async Task<List<DocumentSignOperaation>> GetDocumentSignOperaationsJ(int document_id, int count) {
        List<DocumentSignOperaation> res = new List<DocumentSignOperaation>();
            try
            {
                string connstring = String.Format("Server={0};Port={1};" + 
                    "User Id={2};Password={3};Database=dbname;",
                    Globals.bd_addr, Globals.bd_ip, Globals.bd_log, 
                    Globals.bd_pass);
                NpgsqlConnection conn = new NpgsqlConnection(connstring);
                conn.Open();

                using (var cmd = new NpgsqlCommand("select document_id from DocumentSignOperaation where user_id=" + document_id, conn))
                using (var reader = cmd.ExecuteReader()) {
                    while(reader.Read()) {
                        DocumentSignOperaation temp = new DocumentSignOperaation();
                        temp.user_id = reader.GetInt32(0);
                        temp.type = reader.GetInt32(1);
                        temp.status_id.GetInt32(2);
                        temp.whoAprovedUserId.GetInt32(3);
                        temp.created_dt.GetDateTime(4);
                        temp.edit_dt.GetDateTime(5);
                        temp.document_id.GetInt32(6)
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



        public async Task<List<DocumentSignOperaation>> DeleteDocumentSignOperaationsJ(int document_id, int count) {
            List<DocumentSignOperaation> res = new List<DocumentSignOperaation>();
            try
            {
                string connstring = String.Format("Server={0};Port={1};" + 
                    "User Id={2};Password={3};Database=dbname;",
                    Globals.bd_addr, Globals.bd_ip, Globals.bd_log, 
                    Globals.bd_pass);
                NpgsqlConnection conn = new NpgsqlConnection(connstring);
                conn.Open();

                using (var cmd = new NpgsqlCommand("select document_id from DocumentSignOperaation where document_id=" + document_id, conn))
                using (var reader = cmd.ExecuteReader()) {
                    while(reader.Read()) {
                        DocumentSignOperaation temp = new DocumentSignOperaation();
                        temp.id = reader.GetInt32(0);
                        temp.name = reader.GetString(1);
                        temp.type = reader.GetInt32(2);
                        temp.data = reader.GetString(3);
                        res.Add(temp);

                        using (var command = new NpgsqlCommand
                            ("DELETE FROM DocumentSignOperaation WHERE id ( IN SELECT " + temp.id + " FROM DocumentSignOperaation ORDER BY timestamp DESK LIMIT 10 )" ))
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



        public async Task<Boolean> deposit(int account_id, long amount) {
        Boolean res = false;
         try
            {
                string connstring = String.Format("Server={0};Port={1};" + 
                    "User Id={2};Password={3};Database=dbname;",
                    Globals.bd_addr, Globals.bd_ip, Globals.bd_log, 
                    Globals.bd_pass);
                NpgsqlConnection conn = new NpgsqlConnection(connstring);
                conn.Open();

                using (var cmd = new NpgsqlCommand("select account_id, amount, from accountmeta where account_id=" + account_id, amount))
                using (var reader = cmd.ExecuteReader()) {
                    while(reader.Read()) {
                        AccountMeta temp = new AccountMeta();
                        temp.userId = reader.GetInt32(0);
                        temp.amount = reader.GetInt64(1);
                        if (amount < 0)
                            res = false;
                        else {
                            res = true;
                            using (var command = new NpgsqlCommand("UPDATE  SET amount = " + (id + temp.amount)  + " WHERE name = " + account_id, conn)) {
                            }
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



        public async Task<Boolean> withdraw(int account_id, long amount) {
         Boolean res = false;
            try
            {
                string connstring = String.Format("Server={0};Port={1};" + 
                    "User Id={2};Password={3};Database=dbname;",
                    Globals.bd_addr, Globals.bd_ip, Globals.bd_log, 
                    Globals.bd_pass);
                NpgsqlConnection conn = new NpgsqlConnection(connstring);
                conn.Open();

                using (var cmd = new NpgsqlCommand("select user_id, amount, from accountmeta where user_id=" + account_id, amount))
                using (var reader = cmd.ExecuteReader()) {
                    while(reader.Read()) {
                        AccountMeta temp = new AccountMeta();
                        temp.id = reader.GetInt32(0);
                        temp.name = reader.GetString(1);
                        temp.userId = reader.GetInt32(2);
                        temp.amount = reader.GetInt64(3);
                        temp.frozen = reader.GetInt64(4);
                        if (amount < temp.amount)
                            res = false;
                        else {
                            res = true; 
                            temp.amount -= amount;
                            using (var command = new NpgsqlCommand("UPDATE  SET amount = " + temp.amount + " WHERE name = " + account_id, conn)) {
                            }
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



        public async Task<List<UserMeta>> getUsers(int first, int count) {
            List<UserMeta> res = new List<UserMeta>();
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

                using (var cmd = new NpgsqlCommand("select id, name, user_id, amount, frozen from accountmeta where user_id=" + userId))
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
