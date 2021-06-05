using System;
namespace msIntereface {
    public class StatusMeta {
        // -1 - no status
        // 0 - in progress
        // 1 - wait aprove
        // 2 - aproved
        // 3 - deleted
        public int status_id { get; set; }
        public int whoAprovedUserId { get; set; }
        public DateTime? created_dt { get; set; }
        public DateTime? edit_dt { get; set; }
    }
}