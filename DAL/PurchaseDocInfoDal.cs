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
        public List<PurchaseDocInfo> GetEntityList(out string errText, string purchaseDocName, bool isExact) {
            errText = "";
            try {
                using (SqlConnection conn = new SqlConnection(SQL_CON)) {
                    conn.Open();
                    var sql = "select * from PurchaseDoc";
                    if (!string.IsNullOrEmpty(purchaseDocName)) {
                        if (isExact) {
                            sql += " where PurchaseDocName=@PurchaseDocName";
                        } else
                            sql += " where PurchaseDocName like '%'+@PurchaseDocName+'%'";
                    }
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@PurchaseDocName", purchaseDocName);
                    SqlDataAdapter ada = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    ada.Fill(dt);
                    conn.Close();
                    var list = DataTableHelper.ToList<PurchaseDocInfo>(dt);
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
    }
}
