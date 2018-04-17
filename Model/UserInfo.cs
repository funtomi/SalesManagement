﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManagement.Model {
    public class UserInfo {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool Permission { get; set; }
        public string Remark { get; set; }
    }
}