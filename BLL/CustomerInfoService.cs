using DAL;
using SalesManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManagement.BLL {
    public class CustomerInfoService {
        private CustomerInfoDal dal = new CustomerInfoDal();

        /// <summary>
        /// 查询会员
        /// </summary>
        /// <param name="errText"></param>
        /// <returns></returns>
        public List<CustomerInfo> GetEntityList(out string errText) {
            return dal.GetEntityList(out errText, "", false);
        }

        /// <summary>
        /// 模糊查询会员
        /// </summary>
        /// <param name="errText"></param>
        /// <returns></returns>
        public List<CustomerInfo> QueryCustomerInfo(out string errText, string customerInfo) {
            return dal.GetEntityList(out errText, customerInfo, false);
        }

        /// <summary>
        /// 精确查找会员
        /// </summary>
        /// <param name="errText"></param>
        /// <param name="customerInfo"></param>
        /// <returns></returns>
        public List<CustomerInfo> ExactQueryCustomerInfo(out string errText, string customerInfo) {
            return dal.GetEntityList(out errText, customerInfo, true);
        }
        /// <summary>
        /// 修改会员
        /// </summary>
        /// <param name="errText"></param>
        /// <param name="CustomerInfo"></param>
        /// <returns></returns>
        public int UpdateEntity(out string errText, CustomerInfo customerInfo) {
            return dal.UpdateEntity(out errText, customerInfo);
        }

        /// <summary>
        /// 新增会员
        /// </summary>
        /// <param name="errText"></param>
        /// <param name="customerInfo"></param>
        /// <returns></returns>
        public int InsertEntity(out string errText, CustomerInfo customerInfo) {
            return dal.InsertEntity(out errText, customerInfo);
        }

        /// <summary>
        /// 删除会员
        /// </summary>
        /// <param name="errText"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteEntity(out string errText, Guid id) {
            return dal.DeleteEntity(out errText, id);
        }

    }
}
