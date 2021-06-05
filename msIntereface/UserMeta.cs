namespace msIntereface {
    public class UserMeta {
        // -1 - no priveleges
        // 0 - common user
        // 1 - manager who can aprove
        // 2 - manager who can aprove, modify, delete
        // 3 - admin
        public int priv { get; set; }
        public int id { get; set; }
        public string name { get; set; }
    }
}