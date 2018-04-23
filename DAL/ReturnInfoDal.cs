using DAL;
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
    public class ReturnInfoDal : DalBase {
        /// <summary>
        /// 新增一条退货信息
        /// </summary>
        /// <param name="errText"></param>
        /// <param name="returnInfo"></param>
        /// <returns></returns>
        public int InsertEntity(out string errText, ReturnInfo returnInfo) {
            errText = "";
            try {
                using (SqlConnection conn = new SqlConnection(SQL_CON)) {
                    var sql = "insert into ReturnDoc (ReturnDocId,ReturnDocNo,OperatorId,ReturnTime,Price,Reason) "
                    + "values(@ReturnDocId,@ReturnDocNo,@OperatorId,@ReturnTime,@Price,@Reason)";
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@ReturnDocId", returnInfo.ReturnDocId);
                    cmd.Parameters.AddWithValue("@ReturnDocNo", returnInfo.ReturnDocNo);
                    cmd.Parameters.AddWithValue("@OperatorId", returnInfo.OperatorId);
                    cmd.Parameters.AddWithValue("@ReturnTime", returnInfo.ReturnTime);
                    cmd.Parameters.AddWithValue("@Price", returnInfo.Price);
                    cmd.Parameters.AddWithValue("@Reason", returnInfo.Reason);
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
        /// 获取退货单列表
        /// </summary>
        /// <param name="errText"></param>
        /// <returns></returns>
        public List<ReturnInfo> GetEntityList(out string errText) {
            errText = "";
            try {
                using (SqlConnection conn = new SqlConnection(SQL_CON)) {
                    conn.Open();
                    var sql = "select * from ReturnDoc";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    SqlDataAdapter ada = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    ada.Fill(dt);
                    conn.Close();
                    var list = DataTableHelper.ToList<ReturnInfo>(dt);
                    return list;
                }
            } catch (Exception ex) {
                errText = ex.Message;
                return null;
            }
        }
        /// <summary>
        /// 获取退货单列表
        /// </summary>
        /// <param name="errText"></param>
        /// <returns></returns>
        public List<ReturnInfo> GetEntityListWithSalesNoAndDate(out string errText, string returnNo, DateTime dateTime1, DateTime dateTime2) {
            errText = "";
            try {
                using (SqlConnection conn = new SqlConnection(SQL_CON)) {
                    conn.Open();
                    var sql = "select * from ReturnDoc where ReturnDocNo like '%'+@ReturnDocNo+'%' and ReturnTime between @StartDt and @EndDt";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@ReturnDocNo", returnNo);
                    cmd.Parameters.AddWithValue("@StartDt", dateTime1);
                    cmd.Parameters.AddWithValue("@EndDt", dateTime2);
                    SqlDataAdapter ada = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    ada.Fill(dt);
                    conn.Close();
                    var list = DataTableHelper.ToList<ReturnInfo>(dt);
                    return list;
                }
            } catch (Exception ex) {
                errText = ex.Message;
                return null;
            }
        }
    }


    public class ReturnDetailInfoDal : DalBase {
        /// <summary>
        /// 新增一条退货信息
        /// </summary>
        /// <param name="errText"></param>
        /// <param name="returnInfo"></param>
        /// <returns></returns>
        public int InsertEntity(out string errText, ReturnDetailInfo returnInfo) {
            errText = "";
            try {
                using (SqlConnection conn = new SqlConnection(SQL_CON)) {
                    var sql = "insert into ReturnDetailDoc  (ReturnDetailDocId,ReturnDocId,CommodityId,Count,WarehouseId,Price) "
                    + "values(@ReturnDetailDocId,@ReturnDocId,@CommodityId,@Count,@WarehouseId,@Price)";
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@ReturnDetailDocId", returnInfo.ReturnDetailDocId);
                    cmd.Parameters.AddWithValue("@ReturnDocId", returnInfo.ReturnDocId);
                    cmd.Parameters.AddWithValue("@CommodityId", returnInfo.CommodityId);
                    cmd.Parameters.AddWithValue("@Count", returnInfo.Count);
                    cmd.Parameters.AddWithValue("@WarehouseId", returnInfo.WarehouseId);
                    cmd.Parameters.AddWithValue("@Price", returnInfo.Price);
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
