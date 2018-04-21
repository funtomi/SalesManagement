using System;

namespace SalesManagement.Model {
    public class StockInfo { 
        public Guid WarehouseId { get; set; }
        public int Count { get; set; }
        public int Capacity { get; set; }
        public string Remark { get; set; }
    }

    public class StockDetailInfo {
        public Guid StockDetailId { get; set; }
        public Guid WarehouseId { get; set; }
        public Guid CommodityId { get; set; }
        public int Count { get; set; }
        public string Remark { get; set; }
    }
}
