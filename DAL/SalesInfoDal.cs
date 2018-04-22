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
    }
}
