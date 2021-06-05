using System;
namespace msIntereface {
    public class OperationMeta {
        public int id { get; set; }
        // some cool types
        public int type { get; set; }
        public StatusMeta status { get; set; }
    }
    public class DocumentSignOperaation : OperationMeta {
        public int user_id { get; set; }
        public int document_id { get; set; }
    }
    public class CreditOperaation : OperationMeta {
        public int acount_id { get; set; }
        public DateTime? period { get; set; }
        public string currency { get; set; }
        public long amount { get; set; }
    }

    public class TransactionOperaation : OperationMeta {
        public int from_acount_id { get; set; }
        public int to_acount_id { get; set; }
        public long amount { get; set; }
    }
}