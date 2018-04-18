using SalesManagement.Common;
using SalesManagement.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL {
    public class SupplierInfoDal:DalBase { 

        /// <summary>
        /// 获取供应商列表
        /// </summary>
        /// <param name="errText"></param>
        /// <returns></returns>
        public List<SupplierInfo> GetEntityList(out string errText, string supplierName, bool isExact) {
            errText = "";
            try {
                using (SqlConnection conn = new SqlConnection(SQL_CON)) {
                    conn.Open();
                    var sql = "select * from SupplierInfo";
                    if (!string.IsNullOrEmpty(supplierName)) {
                        if (isExact) {
                            sql += " where SupplierName=@SupplierName";
                        } else
                            sql += " where SupplierName like '%'+@SupplierName+'%'";
                    }
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@SupplierName", supplierName);
                    SqlDataAdapter ada = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    ada.Fill(dt);
                    conn.Close();
                    var list = DataTableHelper.ToList<SupplierInfo>(dt);
                    return list;
                }
            } catch (Exception ex) {
                errText = ex.Message;
                return null;
            }
        }

        /// <summary>
        /// 修改供应商列表
        /// </summary>
        /// <param name="errText"></param>
        /// <param name="SupplierInfo"></param>
        /// <returns></returns>
        public int UpdateEntity(out string errText, SupplierInfo supplierInfo) {
            errText = "";
            try {
                using (SqlConnection conn = new SqlConnection(SQL_CON)) {
                    conn.Open();
                    var sql = "update SupplierInfo set SupplierName=@SupplierName,PhoneNum=@PhoneNum,Address=@Address,Remark=@Remark where SupplierId=@SupplierId";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@SupplierId", supplierInfo.SupplierId);
                    cmd.Parameters.AddWithValue("@SupplierName", supplierInfo.SupplierName);
                    cmd.Parameters.AddWithValue("@PhoneNum", supplierInfo.PhoneNum);
                    cmd.Parameters.AddWithValue("@Address", supplierInfo.Address);
                    cmd.Parameters.AddWithValue("@Remark", supplierInfo.Remark);
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
        /// 新增一条供应商信息
        /// </summary>
        /// <param name="errText"></param>
        /// <param name="SupplierInfo"></param>
        /// <returns></returns>
        public int InsertEntity(out string errText, SupplierInfo SupplierInfo) {
            errText = "";
            try {
                using (SqlConnection conn = new SqlConnection(SQL_CON)) {
                    var sql = "insert into SupplierInfo (SupplierName,PhoneNum,Address,Remark) values(@SupplierName,@PhoneNum,@Address,@Remark)";
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@SupplierName", SupplierInfo.SupplierName);
                    cmd.Parameters.AddWithValue("@PhoneNum", SupplierInfo.PhoneNum);
                    cmd.Parameters.AddWithValue("@Address", SupplierInfo.Address);
                    cmd.Parameters.AddWithValue("@Remark", SupplierInfo.Remark);
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
        /// 删除一条供应商信息
        /// </summary>
        /// <param name="errText"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteEntity(out string errText, Guid id) {
            errText = "";
            try {
                using (SqlConnection conn = new SqlConnection(SQL_CON)) {
                    conn.Open();
                    var sql = "delete SupplierInfo where SupplierId=@SupplierId";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@SupplierId", id);
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
