using DAL;
using SalesManagement.Model;
using System;
using System.Collections.Generic;

namespace SalesManagement.BLL {
    public class WarehouseInfoService {
        private WarehouseDal _dal = new WarehouseDal();
        private StockInfoDal _stockDal = new StockInfoDal();

        /// <summary>
        /// 查询仓库
        /// </summary>
        /// <param name="errText"></param>
        /// <returns></returns>
        public List<WarehouseInfo> GetEntityList(out string errText) {
            return _dal.GetEntityList(out errText, "", false);
        }

        /// <summary>
        /// 模糊查询供应商
        /// </summary>
        /// <param name="errText"></param>
        /// <returns></returns>
        public List<WarehouseInfo> QueryWarehouseInfo(out string errText, string warehouseInfo) {
            return _dal.GetEntityList(out errText, warehouseInfo, false);
        }

        /// <summary>
        /// 精确查找仓库
        /// </summary>
        /// <param name="errText"></param>
        /// <param name="warehouseInfo"></param>
        /// <returns></returns>
        public List<WarehouseInfo> ExactQueryWarehouseInfo(out string errText, string warehouseInfo) {
            return _dal.GetEntityList(out errText, warehouseInfo, true);
        }
        /// <summary>
        /// 修改仓库
        /// </summary>
        /// <param name="errText"></param>
        /// <param name="WarehouseInfo"></param>
        /// <returns></returns>
        public int UpdateEntity(out string errText, WarehouseInfo warehouseInfo) {
            var warehouseList = _stockDal.GetEntityList(out errText, warehouseInfo.WarehouseId,true);
            if (warehouseList==null||warehouseList.Count==0) {
                return 0;
            }
            var warehouse = warehouseList[0];
            if (warehouse.Count>warehouseInfo.Capicity) {
                errText = string.Format("已有库存{0},不可设置库存量为{1}！",warehouse.Count,warehouseInfo.Capicity);
                return 0;
            }
            return _dal.UpdateEntity(out errText, warehouseInfo);
        }

        /// <summary>
        /// 新增仓库
        /// </summary>
        /// <param name="errText"></param>
        /// <param name="warehouseInfo"></param>
        /// <returns></returns>
        public int InsertEntity(out string errText, WarehouseInfo warehouseInfo) {
            warehouseInfo.WarehouseId = Guid.NewGuid();
            var i= _dal.InsertEntity(out errText, warehouseInfo);
            if (i<=0) {
                return i;
            }
            StockInfo info = new StockInfo(){WarehouseId=warehouseInfo.WarehouseId,Count=0,Capacity=warehouseInfo.Capicity,Remark=warehouseInfo.Remark};
            i = _stockDal.InsertEntity(out errText, info);
            return i;
        }

        /// <summary>
        /// 删除仓库
        /// </summary>
        /// <param name="errText"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteEntity(out string errText, Guid id) {
            var list = _stockDal.GetEntityList(out errText, id, true);
            if (list==null||list.Count==0) {
                return _dal.DeleteEntity(out errText, id);
            }
            var info = list[0];
            if (info.Count>0) {
                errText = string.Format("库存容量为{0}，不可删除仓库！",info.Count);
                return 0;
            }
            return _dal.DeleteEntity(out errText, id);
        }
         
    }
}
