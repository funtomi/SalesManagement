using System;

namespace SalesManagement.Model {
    public class CustomerInfo {
        public Guid CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string Sex { get; set; }
        public int Age { get; set; }
        public string PhoneNum { get; set; }
        public string Remark { get; set; }
    }
}
