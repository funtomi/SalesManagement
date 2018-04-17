using DAL;
using SalesManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManagement.BLL {
    public class SizeInfoService {
        private SizeInfoDal dal = new SizeInfoDal();

        /// <summary>
        /// 查询尺码
        /// </summary>
        /// <param name="errText"></param>
        /// <returns></returns>
        public List<SizeInfo> GetEntityList(out string errText) {
            return dal.GetEntityList(out errText, "", false);
        }

        /// <summary>
        /// 模糊查询供应商
        /// </summary>
        /// <param name="errText"></param>
        /// <returns></returns>
        public List<SizeInfo> QuerySizeInfo(out string errText, string SizeInfo) {
            return dal.GetEntityList(out errText, SizeInfo, false);
        }

        /// <summary>
        /// 精确查找尺码
        /// </summary>
        /// <param name="errText"></param>
        /// <param name="SizeInfo"></param>
        /// <returns></returns>
        public List<SizeInfo> ExactQuerySizeInfo(out string errText, string SizeInfo) {
            return dal.GetEntityList(out errText, SizeInfo, true);
        }
        /// <summary>
        /// 修改尺码
        /// </summary>
        /// <param name="errText"></param>
        /// <param name="SizeInfo"></param>
        /// <returns></returns>
        public int UpdateEntity(out string errText, SizeInfo SizeInfo) {
            return dal.UpdateEntity(out errText, SizeInfo);
        }

        /// <summary>
        /// 新增尺码
        /// </summary>
        /// <param name="errText"></param>
        /// <param name="SizeInfo"></param>
        /// <returns></returns>
        public int InsertEntity(out string errText, SizeInfo SizeInfo) {
            return dal.InsertEntity(out errText, SizeInfo);
        }

        /// <summary>
        /// 删除尺码
        /// </summary>
        /// <param name="errText"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteEntity(out string errText, Guid id) {
            return dal.DeleteEntity(out errText, id);
        }
    }
}
