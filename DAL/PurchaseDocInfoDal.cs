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
    public class PurchaseDocInfoDal :DalBase{

        /// <summary>
        /// 获取进货列表
        /// </summary>
        /// <param name="errText"></param>
        /// <returns></returns>
        public List<PurchaseDocClientInfo> GetEntityList(out string errText, string purchaseDocNo, DateTime startDt, DateTime endDt) {
            errText = "";
            try {
                using (SqlConnection conn = new SqlConnection(SQL_CON)) {
                    conn.Open();
                    var sql = "select A.OperatorId,A.Price,A.PurchaseDocId,A.PurchaseDocNo,A.PurchaseTime,A.Remark,A.SupplierId,A.WarehouseId,"
                     + "B.SupplierName,C.UserName,D.WarehouseName from PurchaseDoc as A"
                     + " left join SupplierInfo as B on A.SupplierId=B.SupplierId"
                     + " left join UserInfo as C on A.OperatorId=C.Id"
                     + " left join WarehouseInfo as D on D.WarehouseId=A.WarehouseId";
                    if (!string.IsNullOrEmpty(purchaseDocNo)) {
                        sql += " where A.PurchaseDocNo like '%'+@PurchaseDocNo+'%'";
                        if (startDt != null && endDt != null && startDt < endDt) {
                            sql += " and A.PurchaseTime between @StartTime and @EndTime";
                        }
                    } else {
                        if (startDt != null && endDt != null && startDt < endDt) {
                            sql += " where A.PurchaseTime between @StartTime and @EndTime";
                        }
                    }
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@PurchaseDocNo", purchaseDocNo);
                    cmd.Parameters.AddWithValue("@StartTime", startDt);
                    cmd.Parameters.AddWithValue("@EndTime", endDt);
                    SqlDataAdapter ada = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    ada.Fill(dt);
                    conn.Close();
                    var list = DataTableHelper.ToList<PurchaseDocClientInfo>(dt);
                    return list;
                }
            } catch (Exception ex) {
                errText = ex.Message;
                return null;
            }
        }

        /// <summary>
        /// 获取进货列表
        /// </summary>
        /// <param name="errText"></param>
        /// <returns></returns>
        public List<PurchaseDocClientInfo> GetEntityList(out string errText) {
            errText = "";
            try {
                using (SqlConnection conn = new SqlConnection(SQL_CON)) {
                    conn.Open();
                    var sql = "select A.OperatorId,A.Price,A.PurchaseDocId,A.PurchaseDocNo,A.PurchaseTime,A.Remark,A.SupplierId,A.WarehouseId,"
                     + "B.SupplierName,C.UserName,D.WarehouseName from PurchaseDoc as A"
                     + " left join SupplierInfo as B on A.SupplierId=B.SupplierId"
                     + " left join UserInfo as C on A.OperatorId=C.Id"
                     + " left join WarehouseInfo as D on D.WarehouseId=A.WarehouseId";
                    
                    SqlCommand cmd = new SqlCommand(sql, conn); 
                    SqlDataAdapter ada = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    ada.Fill(dt);
                    conn.Close();
                    var list = DataTableHelper.ToList<PurchaseDocClientInfo>(dt);
                    return list;
                }
            } catch (Exception ex) {
                errText = ex.Message;
                return null;
            }
        }

        /// <summary>
        /// 新增一条进货信息
        /// </summary>
        /// <param name="errText"></param>
        /// <param name="PurchaseDocInfo"></param>
        /// <returns></returns>
        public int InsertEntity(out string errText, PurchaseDocInfo PurchaseDocInfo) {
            errText = "";
            try {
                using (SqlConnection conn = new SqlConnection(SQL_CON)) {
                    var sql = "insert into PurchaseDoc (PurchaseDocId,PurchaseDocNo,SupplierId,PurchaseTime,OperatorId,Price,WarehouseId,Remark) "
                    + "values(@PurchaseDocId,@PurchaseDocNo,@SupplierId,@PurchaseTime,@OperatorId,@Price,@WarehouseId,@Remark)";
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@PurchaseDocId", PurchaseDocInfo.PurchaseDocId);
                    cmd.Parameters.AddWithValue("@PurchaseDocNo", PurchaseDocInfo.PurchaseDocNo);
                    cmd.Parameters.AddWithValue("@SupplierId", PurchaseDocInfo.SupplierId);
                    cmd.Parameters.AddWithValue("@PurchaseTime", PurchaseDocInfo.PurchaseTime);
                    cmd.Parameters.AddWithValue("@OperatorId", PurchaseDocInfo.OperatorId);
                    cmd.Parameters.AddWithValue("@Price", PurchaseDocInfo.Price);
                    cmd.Parameters.AddWithValue("@WarehouseId", PurchaseDocInfo.WarehouseId);
                    cmd.Parameters.AddWithValue("@Remark", PurchaseDocInfo.Remark);
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
    public class PurchaseDetailDocInfoDal : DalBase {

        /// <summary>
        /// 新增一条进货信息
        /// </summary>
        /// <param name="errText"></param>
        /// <param name="PurchaseDocInfo"></param>
        /// <returns></returns>
        public int InsertEntity(out string errText, PurchaseDetailDocInfo PurchaseDocInfo) {
            errText = "";
            try {
                using (SqlConnection conn = new SqlConnection(SQL_CON)) {
                    var sql = "insert into PurchaseDetailDoc (PurchaseDetailDocId,PurchaseDocId,CommodityId,Count,Price,Remark) "
                    + "values(@PurchaseDetailDocId,@PurchaseDocId,@CommodityId,@Count,@Price,@Remark)";
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@PurchaseDetailDocId", PurchaseDocInfo.PurchaseDetailDocId);
                    cmd.Parameters.AddWithValue("@PurchaseDocId", PurchaseDocInfo.PurchaseDocId);
                    cmd.Parameters.AddWithValue("@CommodityId", PurchaseDocInfo.CommodityId);
                    cmd.Parameters.AddWithValue("@Count", PurchaseDocInfo.Count);
                    cmd.Parameters.AddWithValue("@Price", PurchaseDocInfo.Price); 
                    cmd.Parameters.AddWithValue("@Remark", PurchaseDocInfo.Remark);
                    var i = cmd.ExecuteNonQuery();
                    conn.Close();
                    return i;
                }
            } catch (Exception ex) {
                errText = ex.Message;
                return 0;
            }
        }

        public DataTable GetEntityList(out string errText, Guid purchaseDocId) {
            errText = "";
            try {
                using (SqlConnection conn = new SqlConnection(SQL_CON)) {
                    conn.Open();
                    var sql = "select A.PurchaseDocId,B.PurchaseDetailDocId,B.CommodityId,C.CommodityName,B.Count,C.Size,C.Color,C.Unit,C.UnitPrice,B.Price,B.Remark from PurchaseDoc A"
                            +" left join PurchaseDetailDoc B on A.PurchaseDocId=B.PurchaseDocId"
                            +" left join CommodityInfo C on B.CommodityId=C.CommodityId"
                            + " where A.PurchaseDocId=@PurchaseDocId";

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@PurchaseDocId", purchaseDocId);
                    SqlDataAdapter ada = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    ada.Fill(dt);
                    conn.Close();
                    return dt;
                }
            } catch (Exception ex) {
                errText = ex.Message;
                return null;
            }
        }
    }
}
