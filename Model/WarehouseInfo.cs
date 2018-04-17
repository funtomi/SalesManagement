using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManagement.Model {
    public class WarehouseInfo {
        public Guid WarehouseId { get; set; }
        public string WarehouseName { get; set; }
        public string Capicity { get; set; }
        public string Remark { get; set; }
    }
}
