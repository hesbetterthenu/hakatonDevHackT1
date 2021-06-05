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
}