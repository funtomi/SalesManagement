using DAL;
using SalesManagement.Model;
using System;
using System.Collections.Generic;

namespace SalesManagement.BLL {
    public class WarehouseInfoService {
        private WarehouseDal dal = new WarehouseDal();

        /// <summary>
        /// 查询仓库
        /// </summary>
        /// <param name="errText"></param>
        /// <returns></returns>
        public List<WarehouseInfo> GetEntityList(out string errText) {
            return dal.GetEntityList(out errText, "", false);
        }

        /// <summary>
        /// 模糊查询供应商
        /// </summary>
        /// <param name="errText"></param>
        /// <returns></returns>
        public List<WarehouseInfo> QueryWarehouseInfo(out string errText, string warehouseInfo) {
            return dal.GetEntityList(out errText, warehouseInfo, false);
        }

        /// <summary>
        /// 精确查找仓库
        /// </summary>
        /// <param name="errText"></param>
        /// <param name="warehouseInfo"></param>
        /// <returns></returns>
        public List<WarehouseInfo> ExactQueryWarehouseInfo(out string errText, string warehouseInfo) {
            return dal.GetEntityList(out errText, warehouseInfo, true);
        }
        /// <summary>
        /// 修改仓库
        /// </summary>
        /// <param name="errText"></param>
        /// <param name="WarehouseInfo"></param>
        /// <returns></returns>
        public int UpdateEntity(out string errText, WarehouseInfo warehouseInfo) {
            return dal.UpdateEntity(out errText, warehouseInfo);
        }

        /// <summary>
        /// 新增仓库
        /// </summary>
        /// <param name="errText"></param>
        /// <param name="warehouseInfo"></param>
        /// <returns></returns>
        public int InsertEntity(out string errText, WarehouseInfo warehouseInfo) {
            return dal.InsertEntity(out errText, warehouseInfo);
        }

        /// <summary>
        /// 删除仓库
        /// </summary>
        /// <param name="errText"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteEntity(out string errText, Guid id) {
            return dal.DeleteEntity(out errText, id);
        }
         
    }
}
