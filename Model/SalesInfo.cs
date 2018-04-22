using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManagement.Model {
    public class SalesInfo {
        public Guid SalesDocId { get; set; }
        public string SalesDocNo { get; set; }
        public Guid OperatorId { get; set; }
        public DateTime SalesTime { get; set; }
        public Guid CustomerId { get; set; }
        public decimal Price { get; set; }
        public string Remark { get; set; }
    }

    public class SalesDetailInfo {
        public Guid SalesDetailDocId { get; set; }
        public Guid SalesDocId { get; set; }
        public Guid CommodityId { get; set; }
        public int Count { get; set; }
        public decimal UnitPrice { get; set; }
        public float Discount { get; set; }
        public Guid WarehouseId { get; set; }
        public decimal Price { get; set; }
        public string Remark { get; set; }
    }

    public class SalesClientInfo : SalesDetailInfo {
        public string CommodityName;
        public string WarehouseName;
        public string Size;
        public string Color;
        public string Unit;
    }
}
