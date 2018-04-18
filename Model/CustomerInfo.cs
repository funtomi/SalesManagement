using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManagement.Model {
    public class CustomerInfo {
        public Guid CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string Sex { get; set; }
        public int Age { get; set; }
        public string PhoneNum { get; set; }
        public string Remark { get; set; }
    }
}
