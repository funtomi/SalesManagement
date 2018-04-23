using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManagement.Model {
  public class ReturnInfo {
      public Guid ReturnDocId { get; set; }
      public string ReturnDocNo { get; set; }
      public Guid OperatorId { get; set; }
      public DateTime ReturnTime { get; set; } 
      public decimal Price { get; set; }
      public string Reason { get; set; }
    }

  public class ReturnDetailInfo {
      public Guid ReturnDetailDocId { get; set; }
      public Guid ReturnDocId { get; set; }
      public Guid CommodityId { get; set; }
      public int Count { get; set; }
      public Guid WarehouseId { get; set; } 
      public decimal Price { get; set; } 
  }

  public class ReturnClientInfo : ReturnDetailInfo {
      public string IsSelected { get; set; }
      public string CommodityNo { get; set; }
      public string Size { get; set; }
      public string Color { get; set; }
      public string CommodityName { get; set; }
      public decimal UnitPrice { get; set; } 

  }
}
