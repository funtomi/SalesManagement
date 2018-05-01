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
        /// 获取所有有库存的仓库
        /// </summary>
        /// <param name="errText"></param>
        /// <returns></returns>
        public List<StockClientInfo> GetEntityList(out string errText) {
            errText = "";
            try {
                using (SqlConnection conn = new SqlConnection(SQL_CON)) {
                    conn.Open();
                    var sql = "	select A.WarehouseId,A.Count,A.Capacity,B.WarehouseName from Stock A left join WarehouseInfo B on A.WarehouseId=B.WarehouseId"; 
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    SqlDataAdapter ada = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    ada.Fill(dt);
                    conn.Close();
                    var list = DataTableHelper.ToList<StockClientInfo>(dt);
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
        /// 更新仓库容量
        /// </summary>
        /// <param name="errText"></param>
        /// <param name="id"></param>
        /// <param name="capacity"></param>
        /// <returns></returns>
        public int UpdateEntity(out string errText, Guid id,int capacity) {
            errText = "";
            try {
                using (SqlConnection conn = new SqlConnection(SQL_CON)) {
                    conn.Open();
                    var sql = "update Stock set Capacity=@Capacity where WarehouseId=@WarehouseId";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@WarehouseId", id);
                    cmd.Parameters.AddWithValue("@Capacity", capacity);
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

        /// <summary>
        /// 获取库存明细
        /// </summary>
        /// <param name="errText"></param>
        /// <param name="warehouseId"></param>
        /// <returns></returns>
        public List<StockManageInf> GetDetailEntityList(out string errText, Guid warehouseId) {
            errText = "";
            try {
                using (SqlConnection conn = new SqlConnection(SQL_CON)) {
                    conn.Open();
                    var sql = "select A.WarehouseId,A.StockDetailId,A.CommodityId,A.Count,B.CommodityName,B.CommodityNo,B.Color,B.Size,B.UnitPrice,B.Remark from StockDetail A"
                            +" left join CommodityInfo B on A.CommodityId=B.CommodityId"
                            + " where A.WarehouseId=@WarehouseId";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@WarehouseId", warehouseId);
                    SqlDataAdapter ada = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    ada.Fill(dt);
                    var i = cmd.ExecuteNonQuery();
                    conn.Close();
                    var list = DataTableHelper.ToList<StockManageInf>(dt);
                    return list;
                }
            } catch (Exception ex) {
                errText = ex.Message;
                return null;
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

        /// <summary>
        /// 获取容量
        /// </summary>
        /// <param name="errText"></param>
        /// <param name="commodityId"></param>
        /// <returns></returns>
        public StockDetailClientInfo GetCommodityStock(out string errText, Guid commodityId) {
            errText = "";
            try {
                using (SqlConnection conn = new SqlConnection(SQL_CON)) {
                    conn.Open();
                    var sql = "select A.StockDetailId,A.WarehouseId,A.CommodityId,A.Count,A.Remark,B.WarehouseName from StockDetail as A" 
                             +" left join WarehouseInfo as B on A.WarehouseId=B.WarehouseId"
                             +" where A.CommodityId=@CommodityId";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@CommodityId", commodityId);
                    SqlDataAdapter ada = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    ada.Fill(dt);
                    conn.Close();
                    var list = DataTableHelper.ToList<StockDetailClientInfo>(dt);
                    if (list==null||list.Count==0) {
                        return null;
                    }
                    return list[0];
                }
            } catch (Exception ex) {
                errText = ex.Message;
                return null;
            }
        }
    }
}
