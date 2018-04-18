using DAL;
using SalesManagement.Model;
using System;
using System.Collections.Generic;

namespace SalesManagement.BLL {
    public class TypeInfoService {
        private TypeInfoDal dal = new TypeInfoDal();

        /// <summary>
        /// 查询类型
        /// </summary>
        /// <param name="errText"></param>
        /// <returns></returns>
        public List<TypeInfo> GetEntityList(out string errText) {
            return dal.GetEntityList(out errText);
        }

        /// <summary>
        /// 修改类型
        /// </summary>
        /// <param name="errText"></param>
        /// <param name="TypeInfo"></param>
        /// <returns></returns>
        public int UpdateEntity(out string errText, TypeInfo typeInfo) {
            return dal.UpdateEntity(out errText, typeInfo);
        }

        /// <summary>
        /// 新增类型
        /// </summary>
        /// <param name="errText"></param>
        /// <param name="typeInfo"></param>
        /// <returns></returns>
        public int InsertEntity(out string errText, TypeInfo typeInfo) {
            return dal.InsertEntity(out errText, typeInfo);
        }

        /// <summary>
        /// 删除类型
        /// </summary>
        /// <param name="errText"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteEntity(out string errText, Guid id) {
            return dal.DeleteEntity(out errText, id);
        }

    }
}
