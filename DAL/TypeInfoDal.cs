using SalesManagement.Common;
using SalesManagement.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL {
    public class TypeInfoDal : DalBase {

        /// <summary>
        /// 获取类型列表
        /// </summary>
        /// <param name="errText"></param>
        /// <returns></returns>
        public List<TypeInfo> GetEntityList(out string errText) {
            errText = "";
            try {
                using (SqlConnection conn = new SqlConnection(SQL_CON)) {
                    conn.Open();
                    var sql = "select * from TypeInfo";
                    SqlCommand cmd = new SqlCommand(sql, conn); 
                    SqlDataAdapter ada = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    ada.Fill(dt);
                    conn.Close();
                    var list = DataTableHelper.ToList<TypeInfo>(dt);
                    return list;
                }
            } catch (Exception ex) {
                errText = ex.Message;
                return null;
            }
        }

        /// <summary>
        /// 修改类型列表
        /// </summary>
        /// <param name="errText"></param>
        /// <param name="TypeInfo"></param>
        /// <returns></returns>
        public int UpdateEntity(out string errText, TypeInfo typeInfo) {
            errText = "";
            try {
                using (SqlConnection conn = new SqlConnection(SQL_CON)) {
                    conn.Open();
                    var sql = "update TypeInfo set TypeName=@TypeName,ParentId=@ParentId,Remark=@Remark where TypeId=@TypeId";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@TypeId", typeInfo.TypeId);
                    cmd.Parameters.AddWithValue("@TypeName", typeInfo.TypeName);
                    cmd.Parameters.AddWithValue("@ParentId", typeInfo.ParentId); 
                    cmd.Parameters.AddWithValue("@Remark", typeInfo.Remark);
                    var i = cmd.ExecuteNonQuery();
                    conn.Close();
                    return i;
                }
            } catch (Exception ex) {
                errText = ex.Message;
                return 0;
            }
        }

        /// <summary>
        /// 新增一条类型信息
        /// </summary>
        /// <param name="errText"></param>
        /// <param name="TypeInfo"></param>
        /// <returns></returns>
        public int InsertEntity(out string errText, TypeInfo TypeInfo) {
            errText = "";
            try {
                using (SqlConnection conn = new SqlConnection(SQL_CON)) {
                    var sql = "insert into TypeInfo (TypeName,ParentId,Remark) values(@TypeName,@ParentId,@Remark)";
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@TypeName", TypeInfo.TypeName);
                    cmd.Parameters.AddWithValue("@ParentId", TypeInfo.ParentId);
                    cmd.Parameters.AddWithValue("@Remark", TypeInfo.Remark);
                    var i = cmd.ExecuteNonQuery();
                    conn.Close();
                    return i;
                }
            } catch (Exception ex) {
                errText = ex.Message;
                return 0;
            }
        }

        /// <summary>
        /// 删除一条类型信息
        /// </summary>
        /// <param name="errText"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteEntity(out string errText, Guid id) {
            errText = "";
            try {
                using (SqlConnection conn = new SqlConnection(SQL_CON)) {
                    conn.Open();
                    var sql = "delete TypeInfo where TypeId=@TypeId";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@TypeId", id);
                    var i = cmd.ExecuteNonQuery();
                    conn.Close();
                    return i;
                }
            } catch (Exception ex) {
                errText = ex.Message;
                return 0;
            }
        }

    }
}
