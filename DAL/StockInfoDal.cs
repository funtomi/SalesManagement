using SalesManagement.Common;
using SalesManagement.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL {
    public class StockInfoDal : DalBase {

        /// <summary>
        /// 获取仓库列表
        /// </summary>
        /// <param name="errText"></param>
        /// <returns></returns>
        public List<StockInfo> GetEntityList(out string errText, Guid warehouseId, bool isExact) {
            errText = "";
            try {
                using (SqlConnection conn = new SqlConnection(SQL_CON)) {
                    conn.Open();
                    var sql = "select * from Stock";
                    if (warehouseId!=Guid.Empty) {
                        if (isExact) {
                            sql += " where WarehouseId=@WarehouseId";
                        } else
                            sql += " where WarehouseId like '%'+@WarehouseId+'%'";
                    }
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@WarehouseId", warehouseId);
                    SqlDataAdapter ada = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    ada.Fill(dt);
                    conn.Close();
                    var list = DataTableHelper.ToList<StockInfo>(dt);
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
        /// <param name="StockInfo"></param>
        /// <returns></returns>
        public int UpdateEntity(out string errText, StockInfo stockInfo) {
            errText = "";
            try {
                using (SqlConnection conn = new SqlConnection(SQL_CON)) {
                    conn.Open();
                    var sql = "update Stock set Count=@Count,Capacity=@Capacity,Remark=@Remark where WarehouseId=@WarehouseId";
                    SqlCommand cmd = new SqlCommand(sql, conn); 
                    cmd.Parameters.AddWithValue("@WarehouseId", stockInfo.WarehouseId);
                    cmd.Parameters.AddWithValue("@Count", stockInfo.Count);
                    cmd.Parameters.AddWithValue("@Capacity", stockInfo.Capacity);
                    cmd.Parameters.AddWithValue("@Remark", stockInfo.Remark);
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
        /// <param name="StockInfo"></param>
        /// <returns></returns>
        public int InsertEntity(out string errText, StockInfo stockInfo) {
            errText = "";
            try {
                using (SqlConnection conn = new SqlConnection(SQL_CON)) {
                    var sql = "insert into Stock (WarehouseId,Count,Capacity,Remark) values(@WarehouseId,@Count,@Capacity,@Remark)";
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@WarehouseId", stockInfo.WarehouseId);
                    cmd.Parameters.AddWithValue("@Count", stockInfo.Count);
                    cmd.Parameters.AddWithValue("@Capacity", stockInfo.Capacity);
                    cmd.Parameters.AddWithValue("@Remark", stockInfo.Remark);
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
                    var sql = "delete Stock where WarehouseId=@WarehouseId";
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

    public class StockDetailInfoDal : DalBase {

        /// <summary>
        /// 获取仓库列表
        /// </summary>
        /// <param name="errText"></param>
        /// <returns></returns>
        public List<StockDetailInfo> GetEntityList(out string errText, Guid commodityId) {
            errText = "";
            try {
                using (SqlConnection conn = new SqlConnection(SQL_CON)) {
                    conn.Open();
                    var sql = "select * from StockDetail";
                    if (commodityId != Guid.Empty) {
                        sql += " where CommodityId=@CommodityId"; 
                    }
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@CommodityId", commodityId);
                    SqlDataAdapter ada = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    ada.Fill(dt);
                    conn.Close();
                    var list = DataTableHelper.ToList<StockDetailInfo>(dt);
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
        /// <param name="StockInfo"></param>
        /// <returns></returns>
        public int UpdateEntity(out string errText, StockDetailInfo stockInfo) {
            errText = "";
            try {
                using (SqlConnection conn = new SqlConnection(SQL_CON)) {
                    conn.Open();
                    var sql = "update StockDetail set WarehouseId=@WarehouseId,Count=@Count,Remark=@Remark where CommodityId=@CommodityId";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@WarehouseId", stockInfo.WarehouseId); 
                    cmd.Parameters.AddWithValue("@CommodityId", stockInfo.CommodityId);
                    cmd.Parameters.AddWithValue("@Count", stockInfo.Count);
                    cmd.Parameters.AddWithValue("@Remark", stockInfo.Remark);
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
        /// <param name="StockInfo"></param>
        /// <returns></returns>
        public int InsertEntity(out string errText, StockDetailInfo stockInfo) {
            errText = "";
            try {
                using (SqlConnection conn = new SqlConnection(SQL_CON)) {
                    var sql = "insert into StockDetail (WarehouseId,CommodityId,Count,Remark) values(@WarehouseId,@CommodityId,@Count,@Remark)";
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@WarehouseId", stockInfo.WarehouseId);
                    cmd.Parameters.AddWithValue("@CommodityId", stockInfo.CommodityId);
                    cmd.Parameters.AddWithValue("@Count", stockInfo.Count);
                    cmd.Parameters.AddWithValue("@Remark", stockInfo.Remark);
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
        /// 获取库存明细信息
        /// </summary>
        /// <param name="errText"></param>
        /// <param name="warehouseId"></param>
        /// <param name="commodityId"></param>
        /// <returns></returns>
        public List<StockDetailInfo> GetEntityList(out string errText, Guid warehouseId, Guid commodityId) {
            errText = "";
            try {
                using (SqlConnection conn = new SqlConnection(SQL_CON)) {
                    conn.Open();
                    var sql = "select * from StockDetail where WarehouseId=@WarehouseId and CommodityId=@CommodityId"; 
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@CommodityId", commodityId);
                    cmd.Parameters.AddWithValue("@WarehouseId", warehouseId);
                    SqlDataAdapter ada = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    ada.Fill(dt);
                    conn.Close();
                    var list = DataTableHelper.ToList<StockDetailInfo>(dt);
                    return list;
                }
            } catch (Exception ex) {
                errText = ex.Message;
                return null;
            }
        }
    }
}
