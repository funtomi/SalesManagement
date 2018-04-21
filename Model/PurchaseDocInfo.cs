using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManagement.Model {
    public class PurchaseDocInfo {
        public Guid PurchaseDocId { get; set; }
        public string PurchaseDocNo { get; set; }
        public Guid SupplierId { get; set; }
        public DateTime PurchaseTime { get; set; }
        public Guid OperatorId { get; set; }
        public Guid WarehouseId { get; set; }
        public decimal Price { get; set; }
        public string Remark { get; set; }
    }
    public class PurchaseDetailDocInfo {
        public Guid PurchaseDetailDocId { get; set; }
        public Guid PurchaseDocId { get; set; }
        public Guid CommodityId { get; set; }
        public int Count { get; set; }
        public decimal Price { get; set; } 
        public string Remark { get; set; }
    }
}
