using System;

namespace SalesManagement.Model {
    public class CommodityInfo {
        public Guid CommodityId { get; set; }
        public string CommodityNo { get; set; }
        public string CommodityName { get; set; }
        public Guid TypeId { get; set; }
        public string TypeName { get; set; }
        public string Size { get; set; }
        public string Color { get; set; }
        public decimal UnitPrice { get; set; }
        public float Discount { get; set; }
        public string Remark { get; set; }
    }
}
