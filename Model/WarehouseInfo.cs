using System;

namespace SalesManagement.Model {
    public class WarehouseInfo {
        public Guid WarehouseId { get; set; }
        public string WarehouseName { get; set; }
        public string Capicity { get; set; }
        public string Remark { get; set; }
    }
}
