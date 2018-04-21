using System;
using System.Collections.Generic;

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
        public string Unit { get; set; }
        public string Remark { get; set; }
    }

    public class CommodityClientInfo:CommodityInfo {
        public bool IsSelected {
            get { return _isSelected; }
            set { _isSelected = value; }
        }
        private bool _isSelected = false;

        /// <summary>
        /// 从CommodityInfo创建新实例
        /// </summary>
        /// <param name="baseInfo"></param>
        /// <returns></returns>
        public CommodityClientInfo CreateInstance(CommodityInfo baseInfo) {
            if (baseInfo==null) {
                return null;
            }
            var Info = new CommodityClientInfo() { 
            CommodityId=baseInfo.CommodityId,CommodityNo=baseInfo.CommodityNo,CommodityName=baseInfo.CommodityName,TypeId=baseInfo.TypeId,
            TypeName=baseInfo.TypeName,Size=baseInfo.Size,Color=baseInfo.Color,UnitPrice=baseInfo.UnitPrice,Unit=baseInfo.Unit,
            Discount=baseInfo.Discount,Remark=baseInfo.Remark
            };
            return Info;
        }

    }
}
