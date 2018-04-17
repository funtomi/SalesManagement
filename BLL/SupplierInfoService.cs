using DAL;
using SalesManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManagement.BLL {
    public class SupplierInfoService {
        private SupplierInfoDal dal = new SupplierInfoDal();

        /// <summary>
        /// 查询供应商
        /// </summary>
        /// <param name="errText"></param>
        /// <returns></returns>
        public List<SupplierInfo> GetEntityList(out string errText) {
            return dal.GetEntityList(out errText, "", false);
        }

        /// <summary>
        /// 模糊查询供应商
        /// </summary>
        /// <param name="errText"></param>
        /// <returns></returns>
        public List<SupplierInfo> QuerySupplierInfo(out string errText, string supplierInfo) {
            return dal.GetEntityList(out errText, supplierInfo, false);
        }

        /// <summary>
        /// 精确查找供应商
        /// </summary>
        /// <param name="errText"></param>
        /// <param name="supplierInfo"></param>
        /// <returns></returns>
        public List<SupplierInfo> ExactQuerySupplierInfo(out string errText, string supplierInfo) {
            return dal.GetEntityList(out errText, supplierInfo, true);
        }
        /// <summary>
        /// 修改供应商
        /// </summary>
        /// <param name="errText"></param>
        /// <param name="SupplierInfo"></param>
        /// <returns></returns>
        public int UpdateEntity(out string errText, SupplierInfo supplierInfo) {
            return dal.UpdateEntity(out errText, supplierInfo);
        }

        /// <summary>
        /// 新增供应商
        /// </summary>
        /// <param name="errText"></param>
        /// <param name="supplierInfo"></param>
        /// <returns></returns>
        public int InsertEntity(out string errText, SupplierInfo supplierInfo) {
            return dal.InsertEntity(out errText, supplierInfo);
        }

        /// <summary>
        /// 删除供应商
        /// </summary>
        /// <param name="errText"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteEntity(out string errText, Guid id) {
            return dal.DeleteEntity(out errText, id);
        }
         
    }
}
