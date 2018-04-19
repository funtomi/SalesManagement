using SalesManagement.Common;
using SalesManagement.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL {
    public class CommodityInfoDal : DalBase {

        /// <summary>
        /// 获取商品列表
        /// </summary>
        /// <param name="errText"></param>
        /// <returns></returns>
        public List<CommodityInfo> GetEntityList(out string errText, string commodityNo, bool isExact) {
            errText = "";
            try {
                using (SqlConnection conn = new SqlConnection(SQL_CON)) {
                    conn.Open();
                    var sql = "select A.CommodityId,A.CommodityNo,A.CommodityName,A.TypeId,A.Size,A.Color,A.UnitPrice,A.Discount,A.Remark,B.TypeName"
                        +" from CommodityInfo as A"
                        +" left join TypeInfo as B on A.TypeId=B.TypeId";
                    if (!string.IsNullOrEmpty(commodityNo)) {
                        if (isExact) {
                            sql += " where A.CommodityNo=@CommodityNo";
                        } else
                            sql += " where A.CommodityNo like '%'+@CommodityNo+'%'";
                    }
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@CommodityNo", commodityNo);
                    SqlDataAdapter ada = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    ada.Fill(dt);
                    conn.Close();
                    var list = DataTableHelper.ToList<CommodityInfo>(dt);
                    return list;
                }
            } catch (Exception ex) {
                errText = ex.Message;
                return null;
            }
        }

        /// <summary>
        /// 获取商品列表
        /// </summary>
        /// <param name="errText"></param>
        /// <returns></returns>
        public List<CommodityInfo> GetEntityList(out string errText, Guid typeId) {
            errText = "";
            try {
                using (SqlConnection conn = new SqlConnection(SQL_CON)) {
                    conn.Open();
                    var sql = "select A.CommodityId,A.CommodityNo,A.CommodityName,A.TypeId,A.Size,A.Color,A.UnitPrice,A.Discount,A.Remark,B.TypeName"
                        +" from CommodityInfo as A"
                        +" left join TypeInfo as B on A.TypeId=B.TypeId"
                        +" where A.TypeId=@TypeId"; 
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@TypeId", typeId);
                    SqlDataAdapter ada = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    ada.Fill(dt);
                    conn.Close();
                    var list = DataTableHelper.ToList<CommodityInfo>(dt);
                    return list;
                }
            } catch (Exception ex) {
                errText = ex.Message;
                return null;
            }
        }

        /// <summary>
        /// 修改商品列表
        /// </summary>
        /// <param name="errText"></param>
        /// <param name="CommodityInfo"></param>
        /// <returns></returns>
        public int UpdateEntity(out string errText, CommodityInfo commodityInfo) {
            errText = "";
            try {
                using (SqlConnection conn = new SqlConnection(SQL_CON)) {
                    conn.Open();
                    var sql = "update CommodityInfo set CommodityName=@CommodityName,TypeId=@CommodityNo,CommodityNo=@CommodityNo,Size=@Size,Color=@Color,UnitPrice=@UnitPrice,Discount=@Discount,Remark=@Remark where CommodityId=@CommodityId";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@CommodityId", commodityInfo.CommodityId);
                    cmd.Parameters.AddWithValue("@CommodityName", commodityInfo.CommodityName);
                    cmd.Parameters.AddWithValue("@TypeId", commodityInfo.TypeId);
                    cmd.Parameters.AddWithValue("@CommodityNo", commodityInfo.CommodityNo);
                    cmd.Parameters.AddWithValue("@Size", commodityInfo.Size);
                    cmd.Parameters.AddWithValue("@Color", commodityInfo.Color);
                    cmd.Parameters.AddWithValue("@UnitPrice", commodityInfo.UnitPrice);
                    cmd.Parameters.AddWithValue("@Discount", commodityInfo.Discount);
                    cmd.Parameters.AddWithValue("@Remark", commodityInfo.Remark);
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
        /// 新增一条商品信息
        /// </summary>
        /// <param name="errText"></param>
        /// <param name="commodityInfo"></param>
        /// <returns></returns>
        public int InsertEntity(out string errText, CommodityInfo commodityInfo) {
            errText = "";
            try {
                using (SqlConnection conn = new SqlConnection(SQL_CON)) {
                    var sql = "insert into CommodityInfo (CommodityName,TypeId,CommodityNo,Size,Color,UnitPrice,Discount,Remark)"
                    + " values(@CommodityName,@TypeId,@CommodityNo,@Size,@Color,@UnitPrice,@Discount,@Remark)";
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@CommodityId", commodityInfo.CommodityId);
                    cmd.Parameters.AddWithValue("@CommodityName", commodityInfo.CommodityName);
                    cmd.Parameters.AddWithValue("@TypeId", commodityInfo.TypeId);
                    cmd.Parameters.AddWithValue("@CommodityNo", commodityInfo.CommodityNo);
                    cmd.Parameters.AddWithValue("@Size", commodityInfo.Size);
                    cmd.Parameters.AddWithValue("@Color", commodityInfo.Color);
                    cmd.Parameters.AddWithValue("@UnitPrice", commodityInfo.UnitPrice);
                    cmd.Parameters.AddWithValue("@Discount", commodityInfo.Discount);
                    cmd.Parameters.AddWithValue("@Remark", commodityInfo.Remark);
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
        /// 删除一条商品信息
        /// </summary>
        /// <param name="errText"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteEntity(out string errText, Guid id) {
            errText = "";
            try {
                using (SqlConnection conn = new SqlConnection(SQL_CON)) {
                    conn.Open();
                    var sql = "delete CommodityInfo where CommodityId=@CommodityId";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@CommodityId", id);
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
