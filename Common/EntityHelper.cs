using SalesManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManagement.Common {
    public static class EntityHelper {

        /// <summary>
        /// 从CommodityInfo的集合创建新的集合
        /// </summary>
        /// <param name="baseInfos"></param>
        /// <returns></returns>
        public static List<CommodityClientInfo> CreateInstanceCollection(List<CommodityInfo> baseInfos) {
            if (baseInfos == null || baseInfos.Count == 0) {
                return null;
            }
            var list = new List<CommodityClientInfo>();
            foreach (var item in baseInfos) {
                CommodityClientInfo newItem = new CommodityClientInfo();
                list.Add(newItem.CreateInstance(item));
            }
            return list;
        }
    }
}
