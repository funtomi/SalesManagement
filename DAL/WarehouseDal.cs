using SalesManagement.Common;
using SalesManagement.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL {
    public class WarehouseDal:DalBase {
        /// <summary>
        /// 获取仓库列表
        /// </summary>
        /// <param name="errText"></param>
        /// <returns></returns>
        public List<WarehouseInfo> GetEntityList(out string errText, string warehouseName, bool isExact) {
            errText = "";
            try {
                using (SqlConnection conn = new SqlConnection(SQL_CON)) {
                    conn.Open();
                    var sql = "select * from WarehouseInfo";
                    if (!string.IsNullOrEmpty(warehouseName)) {
                        if (isExact) {
                            sql += " where WarehouseName=@WarehouseName";
                        } else
                            sql += " where WarehouseName like '%'+@WarehouseName+'%'";
                    }
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@WarehouseName", warehouseName);
                    SqlDataAdapter ada = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    ada.Fill(dt);
                    conn.Close();
                    var list = DataTableHelper.ToList<WarehouseInfo>(dt);
                    return list;
                }
            } catch (Exception ex) {
                errText = ex.Message;
                return null;
            }
        }

        /// <summary>
        /// 修改仓库列表
        /// </summary>
        /// <param name="errText"></param>
        /// <param name="WarehouseInfo"></param>
        /// <returns></returns>
        public int UpdateEntity(out string errText, WarehouseInfo warehouseInfo) {
            errText = "";
            try {
                using (SqlConnection conn = new SqlConnection(SQL_CON)) {
                    conn.Open();
                    var sql = "update WarehouseInfo set WarehouseName=@WarehouseName,Capicity=@Capicity,Remark=@Remark where WarehouseId=@WarehouseId";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@WarehouseId", warehouseInfo.WarehouseId);
                    cmd.Parameters.AddWithValue("@WarehouseName", warehouseInfo.WarehouseName);
                    cmd.Parameters.AddWithValue("@Capicity", warehouseInfo.Capicity);
                    cmd.Parameters.AddWithValue("@Remark", warehouseInfo.Remark);
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
        /// 新增一条仓库信息
        /// </summary>
        /// <param name="errText"></param>
        /// <param name="WarehouseInfo"></param>
        /// <returns></returns>
        public int InsertEntity(out string errText, WarehouseInfo WarehouseInfo) {
            errText = "";
            try {
                using (SqlConnection conn = new SqlConnection(SQL_CON)) {
                    var sql = "insert into WarehouseInfo (WarehouseName,Capicity,Remark) values(@WarehouseName,@Capicity,@Remark)";
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@WarehouseName", WarehouseInfo.WarehouseName);
                    cmd.Parameters.AddWithValue("@Capicity", WarehouseInfo.Capicity);
                    cmd.Parameters.AddWithValue("@Remark", WarehouseInfo.Remark);
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
        /// 删除一条仓库信息
        /// </summary>
        /// <param name="errText"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteEntity(out string errText, Guid id) {
            errText = "";
            try {
                using (SqlConnection conn = new SqlConnection(SQL_CON)) {
                    conn.Open();
                    var sql = "delete WarehouseInfo where WarehouseId=@WarehouseId";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@WarehouseId", id);
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
