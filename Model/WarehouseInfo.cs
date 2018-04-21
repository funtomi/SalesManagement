using System;

namespace SalesManagement.Model {
    public class WarehouseInfo {
        public Guid WarehouseId { get; set; }
        public string WarehouseName { get; set; }
        public int Capicity { get; set; }
        public string Remark { get; set; }
    }
}
