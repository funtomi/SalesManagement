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

    public class StockDetailClientInfo : StockDetailInfo {
        public string WarehouseName{get;set;}
    }

    public class StockClientInfo  {
        public string WarehouseName{get;set;}
        public Guid WarehouseId { get; set; }
        public int Count { get; set; }
        public int Capacity { get; set; }
    }

    public class StockManageInf {
        public Guid StockDetailId { get; set; }
        public Guid WarehouseId { get; set; }
        public Guid CommodityId { get; set; }
        public int Count { get; set; }
        public string CommodityNo { get; set; }
        public string CommodityName { get; set; }
        public string Size { get; set; }
        public string Color { get; set; }
        public decimal UnitPrice { get; set; }
        public string Remark { get; set; }

    }
}
