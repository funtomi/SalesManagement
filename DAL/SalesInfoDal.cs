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
    public class SalesInfoDal : DalBase {
 
        /// <summary>
        /// 新增一条销售信息
        /// </summary>
        /// <param name="errText"></param>
        /// <param name="SalesInfo"></param>
        /// <returns></returns>
        public int InsertEntity(out string errText, SalesInfo SalesInfo) {
            errText = "";
            try {
                using (SqlConnection conn = new SqlConnection(SQL_CON)) {
                    var sql = "insert into SalesDoc (SalesDocId,SalesDocNo,OperatorId,SalesTime,Price,CustomerId) "
                    + "values(@SalesDocId,@SalesDocNo,@OperatorId,@SalesTime,@Price,@CustomerId)";
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@SalesDocId", SalesInfo.SalesDocId);
                    cmd.Parameters.AddWithValue("@SalesDocNo", SalesInfo.SalesDocNo);
                    cmd.Parameters.AddWithValue("@OperatorId", SalesInfo.OperatorId);
                    cmd.Parameters.AddWithValue("@SalesTime", SalesInfo.SalesTime);
                    cmd.Parameters.AddWithValue("@Price", SalesInfo.Price);
                    cmd.Parameters.AddWithValue("@CustomerId", SalesInfo.CustomerId); 
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
        /// 获取销售订单列表
        /// </summary>
        /// <param name="errText"></param>
        /// <returns></returns>
        public List<SalesInfo> GetEntityList(out string errText) {
            errText = "";
            try {
                using (SqlConnection conn = new SqlConnection(SQL_CON)) {
                    conn.Open();
                    var sql = "select * from SalesDoc";
                    SqlCommand cmd = new SqlCommand(sql, conn); 
                    SqlDataAdapter ada = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    ada.Fill(dt);
                    conn.Close();
                    var list = DataTableHelper.ToList<SalesInfo>(dt);
                    return list;
                }
            } catch (Exception ex) {
                errText = ex.Message;
                return null;
            }
        }
        /// <summary>
        /// 获取销售订单列表
        /// </summary>
        /// <param name="errText"></param>
        /// <returns></returns>
        public List<SalesInfo> GetEntityListWithSalesNoAndDate(out string errText,string salesNo,DateTime dtStart,DateTime dtEnd) {
            errText = "";
            try {
                using (SqlConnection conn = new SqlConnection(SQL_CON)) {
                    conn.Open();
                    var sql = "select * from SalesDoc where SalesDocNo like '%'+@SalesDocNo+'%' and SalesTime between @StartDt and @EndDt";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@SalesDocNo", salesNo);
                    cmd.Parameters.AddWithValue("@StartDt", dtStart);
                    cmd.Parameters.AddWithValue("@EndDt", dtEnd);
                    SqlDataAdapter ada = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    ada.Fill(dt);
                    conn.Close();
                    var list = DataTableHelper.ToList<SalesInfo>(dt);
                    return list;
                }
            } catch (Exception ex) {
                errText = ex.Message;
                return null;
            }
        }
    }
    public class SalesDetailInfoDal: DalBase {

        /// <summary>
        /// 新增一条销售信息
        /// </summary>
        /// <param name="errText"></param>
        /// <param name="salesInfo"></param>
        /// <returns></returns>
        public int InsertEntity(out string errText, SalesDetailInfo salesInfo) {
            errText = "";
            try {
                using (SqlConnection conn = new SqlConnection(SQL_CON)) {
                    var sql = "insert into SalesDetailDoc  (SalesDetailDocId,SalesDocId,CommodityId,Count,Price,UnitPrice,Discount,WarehouseId,Remark) "
                    + "values(@SalesDetailDocId,@SalesDocId,@CommodityId,@Count,@Price,@UnitPrice,@Discount,@WarehouseId,@Remark)";
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@SalesDetailDocId", salesInfo.SalesDetailDocId);
                    cmd.Parameters.AddWithValue("@SalesDocId", salesInfo.SalesDocId);
                    cmd.Parameters.AddWithValue("@CommodityId", salesInfo.CommodityId);
                    cmd.Parameters.AddWithValue("@Count", salesInfo.Count);
                    cmd.Parameters.AddWithValue("@Price", salesInfo.Price);
                    cmd.Parameters.AddWithValue("@UnitPrice", salesInfo.UnitPrice);
                    cmd.Parameters.AddWithValue("@Discount", salesInfo.Discount);
                    cmd.Parameters.AddWithValue("@WarehouseId", salesInfo.WarehouseId);
                    cmd.Parameters.AddWithValue("@Remark", salesInfo.Remark);
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
        /// 获取销售列表
        /// </summary>
        /// <param name="errText"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public List<SalesClientInfo> GetEntityList(out string errText, DateTime startDate, DateTime endDate) {
            errText = "";
            try {
                using (SqlConnection conn = new SqlConnection(SQL_CON)) {
                    conn.Open();
                    var sql = "select A.SalesDetailDocId,A.SalesDocId,A.CommodityId,A.Count,A.Discount,A.Price,A.Remark,"
                    + "A.UnitPrice,A.WarehouseId,B.WarehouseName,C.CommodityName,C.Size,C.Color,C.CommodityNo from SalesDetailDoc as A "
                    +"left join WarehouseInfo as B on A.WarehouseId=B.WarehouseId"
                    +" left join CommodityInfo as C on A.CommodityId=C.CommodityId"
                    +" where A.SalesDetailDocId in"
                    +" (select SalesDetailDocId from SalesDoc  where SalesTime between @StartDate and @EndDate)"; 
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@StartDate", startDate);
                    cmd.Parameters.AddWithValue("@EndDate", endDate);
                    SqlDataAdapter ada = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    ada.Fill(dt);
                    conn.Close();
                    var list = DataTableHelper.ToList<SalesClientInfo>(dt);
                    return list;
                }
            } catch (Exception ex) {
                errText = ex.Message;
                return null;
            }
        }

        /// <summary>
        /// 获取销售列表
        /// </summary>
        /// <param name="errText"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public List<SalesClientInfo> GetEntityListWithCommodityNo(out string errText,string commodityNo, DateTime startDate, DateTime endDate) {
            errText = "";
            try {
                using (SqlConnection conn = new SqlConnection(SQL_CON)) {
                    conn.Open();
                    var sql = "select A.SalesDetailDocId,A.SalesDocId,A.CommodityId,A.Count,A.Discount,A.Price,A.Remark,"
                    + "A.UnitPrice,A.WarehouseId,B.WarehouseName,C.CommodityName,C.Size,C.Color,C.CommodityNo from SalesDetailDoc as A "
                    + "left join WarehouseInfo as B on A.WarehouseId=B.WarehouseId"
                    + " left join CommodityInfo as C on A.CommodityId=C.CommodityId"
                    + " where A.SalesDetailDocId in"
                    + " (select SalesDetailDocId from SalesDoc  where SalesTime between @StartDate and @EndDate and CommodityNo like '%'+@CommodityNo+'%')";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@StartDate", startDate);
                    cmd.Parameters.AddWithValue("@EndDate", endDate);
                    cmd.Parameters.AddWithValue("@CommodityNo", commodityNo);
                    SqlDataAdapter ada = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    ada.Fill(dt);
                    conn.Close();
                    var list = DataTableHelper.ToList<SalesClientInfo>(dt);
                    return list;
                }
            } catch (Exception ex) {
                errText = ex.Message;
                return null;
            }
        }

        /// <summary>
        /// 获取销售列表
        /// </summary>
        /// <param name="errText"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public List<SalesClientInfo> GetEntityListWithSalesNo(out string errText, string salesNo, DateTime startDate, DateTime endDate) {
            errText = "";
            try {
                using (SqlConnection conn = new SqlConnection(SQL_CON)) {
                    conn.Open();
                    var sql = "select A.SalesDetailDocId,A.SalesDocId,A.CommodityId,A.Count,A.Discount,A.Price,A.Remark,"
                    + "A.UnitPrice,A.WarehouseId,B.WarehouseName,C.CommodityName,C.Size,C.Color,C.CommodityNo from SalesDetailDoc as A "
                    + "left join WarehouseInfo as B on A.WarehouseId=B.WarehouseId"
                    + " left join CommodityInfo as C on A.CommodityId=C.CommodityId"
                    + " where A.SalesDetailDocId in"
                    + " (select SalesDetailDocId from SalesDoc  where SalesTime between @StartDate and @EndDate and SalesDocNo like '%'+@SalesDocNo+'%')";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@StartDate", startDate);
                    cmd.Parameters.AddWithValue("@EndDate", endDate);
                    cmd.Parameters.AddWithValue("@SalesDocNo", salesNo);
                    SqlDataAdapter ada = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    ada.Fill(dt);
                    conn.Close();
                    var list = DataTableHelper.ToList<SalesClientInfo>(dt);
                    return list;
                }
            } catch (Exception ex) {
                errText = ex.Message;
                return null;
            }
        }
    }
}
