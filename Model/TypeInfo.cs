using System;

namespace SalesManagement.Model {
    public class TypeInfo {
        public Guid TypeId { get; set; }
        public Guid ParentId { get; set; }
        public string TypeName { get; set; } 
    }
}
