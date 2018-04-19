using DAL;
using SalesManagement.Model;
using System;
using System.Collections.Generic;

namespace SalesManagement.BLL {
    public class CommodityInfoService {
        private CommodityInfoDal dal = new CommodityInfoDal();

        /// <summary>
        /// 查询商品
        /// </summary>
        /// <param name="errText"></param>
        /// <returns></returns>
        public List<CommodityInfo> GetEntityList(out string errText) {
            return dal.GetEntityList(out errText, "", false);
        }

        /// <summary>
        /// 查询商品
        /// </summary>
        /// <param name="errText"></param>
        /// <returns></returns>
        public List<CommodityInfo> GetEntityList(out string errText, Guid typeId) {
            return dal.GetEntityList(out errText, typeId);
        }

        /// <summary>
        /// 模糊查询商品
        /// </summary>
        /// <param name="errText"></param>
        /// <returns></returns>
        public List<CommodityInfo> QueryCommodityInfo(out string errText, string commodityInfo) {
            return dal.GetEntityList(out errText, commodityInfo, false);
        }

        /// <summary>
        /// 精确查找商品
        /// </summary>
        /// <param name="errText"></param>
        /// <param name="commodityInfo"></param>
        /// <returns></returns>
        public List<CommodityInfo> ExactQueryCommodityInfo(out string errText, string commodityInfo) {
            return dal.GetEntityList(out errText, commodityInfo, true);
        }
        /// <summary>
        /// 修改商品
        /// </summary>
        /// <param name="errText"></param>
        /// <param name="CommodityInfo"></param>
        /// <returns></returns>
        public int UpdateEntity(out string errText, CommodityInfo commodityInfo) {
            return dal.UpdateEntity(out errText, commodityInfo);
        }

        /// <summary>
        /// 新增商品
        /// </summary>
        /// <param name="errText"></param>
        /// <param name="commodityInfo"></param>
        /// <returns></returns>
        public int InsertEntity(out string errText, CommodityInfo commodityInfo) {
            return dal.InsertEntity(out errText, commodityInfo);
        }

        /// <summary>
        /// 删除商品
        /// </summary>
        /// <param name="errText"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteEntity(out string errText, Guid id) {
            return dal.DeleteEntity(out errText, id);
        }

    }
}
