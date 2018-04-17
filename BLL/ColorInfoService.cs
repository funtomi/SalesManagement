using DAL;
using SalesManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManagement.BLL {
    public class ColorInfoService {
        private ColorInfoDal dal = new ColorInfoDal();

        /// <summary>
        /// 查询颜色
        /// </summary>
        /// <param name="errText"></param>
        /// <returns></returns>
        public List<ColorInfo> GetEntityList(out string errText) {
            return dal.GetEntityList(out errText, "", false);
        }

        /// <summary>
        /// 模糊查询供应商
        /// </summary>
        /// <param name="errText"></param>
        /// <returns></returns>
        public List<ColorInfo> QueryColorInfo(out string errText, string colorInfo) {
            return dal.GetEntityList(out errText, colorInfo, false);
        }

        /// <summary>
        /// 精确查找颜色
        /// </summary>
        /// <param name="errText"></param>
        /// <param name="colorInfo"></param>
        /// <returns></returns>
        public List<ColorInfo> ExactQueryColorInfo(out string errText, string colorInfo) {
            return dal.GetEntityList(out errText, colorInfo, true);
        }
        /// <summary>
        /// 修改颜色
        /// </summary>
        /// <param name="errText"></param>
        /// <param name="colorInfo"></param>
        /// <returns></returns>
        public int UpdateEntity(out string errText, ColorInfo colorInfo) {
            return dal.UpdateEntity(out errText, colorInfo);
        }

        /// <summary>
        /// 新增颜色
        /// </summary>
        /// <param name="errText"></param>
        /// <param name="colorInfo"></param>
        /// <returns></returns>
        public int InsertEntity(out string errText, ColorInfo colorInfo) {
            return dal.InsertEntity(out errText, colorInfo);
        }

        /// <summary>
        /// 删除颜色
        /// </summary>
        /// <param name="errText"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteEntity(out string errText, Guid id) {
            return dal.DeleteEntity(out errText, id);
        }
    }
}
