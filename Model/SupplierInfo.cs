using System;

namespace SalesManagement.Model {
    public class SupplierInfo {
        public Guid SupplierId { get; set; }
        public string SupplierName { get; set; }
        public string PhoneNum { get; set; }
        public string Address { get; set; }
        public string Remark { get; set; }
    }
}
