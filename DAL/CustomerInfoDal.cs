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
    public class CustomerInfoDal : DalBase {

        /// <summary>
        /// 获取会员列表
        /// </summary>
        /// <param name="errText"></param>
        /// <returns></returns>
        public List<CustomerInfo> GetEntityList(out string errText, string customerName, bool isExact) {
            errText = "";
            try {
                using (SqlConnection conn = new SqlConnection(SQL_CON)) {
                    conn.Open();
                    var sql = "select * from CustomerInfo";
                    if (!string.IsNullOrEmpty(customerName)) {
                        if (isExact) {
                            sql += " where CustomerName=@CustomerName";
                        } else
                            sql += " where CustomerName like '%'+@CustomerName+'%'";
                    }
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@CustomerName", customerName);
                    SqlDataAdapter ada = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    ada.Fill(dt);
                    conn.Close();
                    var list = DataTableHelper.ToList<CustomerInfo>(dt);
                    return list;
                }
            } catch (Exception ex) {
                errText = ex.Message;
                return null;
            }
        }

        /// <summary>
        /// 修改会员列表
        /// </summary>
        /// <param name="errText"></param>
        /// <param name="CustomerInfo"></param>
        /// <returns></returns>
        public int UpdateEntity(out string errText, CustomerInfo customerInfo) {
            errText = "";
            try {
                using (SqlConnection conn = new SqlConnection(SQL_CON)) {
                    conn.Open();
                    var sql = "update CustomerInfo set CustomerName=@CustomerName,Sex=@Sex,PhoneNum=@PhoneNum,Age=@Age,Remark=@Remark where CustomerId=@CustomerId";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@CustomerId", customerInfo.CustomerId);
                    cmd.Parameters.AddWithValue("@CustomerName", customerInfo.CustomerName);
                    cmd.Parameters.AddWithValue("@Sex", customerInfo.Sex);
                    cmd.Parameters.AddWithValue("@PhoneNum", customerInfo.PhoneNum);
                    cmd.Parameters.AddWithValue("@Age", customerInfo.Age);
                    cmd.Parameters.AddWithValue("@Remark", customerInfo.Remark);
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
        /// 新增一条会员信息
        /// </summary>
        /// <param name="errText"></param>
        /// <param name="CustomerInfo"></param>
        /// <returns></returns>
        public int InsertEntity(out string errText, CustomerInfo CustomerInfo) {
            errText = "";
            try {
                using (SqlConnection conn = new SqlConnection(SQL_CON)) {
                    var sql = "insert into CustomerInfo (CustomerName,Sex,PhoneNum,Age,Remark) values(@CustomerName,@Sex,@PhoneNum,@Age,@Remark)";
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@CustomerName", CustomerInfo.CustomerName);
                    cmd.Parameters.AddWithValue("@Sex", CustomerInfo.Sex);
                    cmd.Parameters.AddWithValue("@PhoneNum", CustomerInfo.PhoneNum);
                    cmd.Parameters.AddWithValue("@Age", CustomerInfo.Age);
                    cmd.Parameters.AddWithValue("@Remark", CustomerInfo.Remark);
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
        /// 删除一条会员信息
        /// </summary>
        /// <param name="errText"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteEntity(out string errText, Guid id) {
            errText = "";
            try {
                using (SqlConnection conn = new SqlConnection(SQL_CON)) {
                    conn.Open();
                    var sql = "delete CustomerInfo where CustomerId=@CustomerId";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@CustomerId", id);
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
