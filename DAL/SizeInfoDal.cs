using SalesManagement.Common;
using SalesManagement.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL {
    public class SizeInfoDal:DalBase {
        /// <summary>
        /// 获取尺码列表
        /// </summary>
        /// <param name="errText"></param>
        /// <returns></returns>
        public List<SizeInfo> GetEntityList(out string errText, string sizeName, bool isExact) {
            errText = "";
            try {
                using (SqlConnection conn = new SqlConnection(SQL_CON)) {
                    conn.Open();
                    var sql = "select * from SizeInfo";
                    if (!string.IsNullOrEmpty(sizeName)) {
                        if (isExact) {
                            sql += " where SizeName=@SizeName";
                        } else
                            sql += " where SizeName like '%'+@SizeName+'%'";
                    }
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@SizeName", sizeName);
                    SqlDataAdapter ada = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    ada.Fill(dt);
                    conn.Close();
                    var list = DataTableHelper.ToList<SizeInfo>(dt);
                    return list;
                }
            } catch (Exception ex) {
                errText = ex.Message;
                return null;
            }
        }

        /// <summary>
        /// 修改尺码列表
        /// </summary>
        /// <param name="errText"></param>
        /// <param name="SizeInfo"></param>
        /// <returns></returns>
        public int UpdateEntity(out string errText, SizeInfo sizeInfo) {
            errText = "";
            try {
                using (SqlConnection conn = new SqlConnection(SQL_CON)) {
                    conn.Open();
                    var sql = "update SizeInfo set SizeName=@SizeName,Remark=@Remark where SizeId=@SizeId";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@SizeId", sizeInfo.SizeId);
                    cmd.Parameters.AddWithValue("@SizeName", sizeInfo.SizeName); 
                    cmd.Parameters.AddWithValue("@Remark", sizeInfo.Remark);
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
        /// 新增一条尺码信息
        /// </summary>
        /// <param name="errText"></param>
        /// <param name="SizeInfo"></param>
        /// <returns></returns>
        public int InsertEntity(out string errText, SizeInfo SizeInfo) {
            errText = "";
            try {
                using (SqlConnection conn = new SqlConnection(SQL_CON)) {
                    var sql = "insert into SizeInfo (SizeName,Remark) values(@SizeName,@Remark)";
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@SizeName", SizeInfo.SizeName); 
                    cmd.Parameters.AddWithValue("@Remark", SizeInfo.Remark);
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
        /// 删除一条尺码信息
        /// </summary>
        /// <param name="errText"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteEntity(out string errText, Guid id) {
            errText = "";
            try {
                using (SqlConnection conn = new SqlConnection(SQL_CON)) {
                    conn.Open();
                    var sql = "delete SizeInfo where SizeId=@SizeId";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@SizeId", id);
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
