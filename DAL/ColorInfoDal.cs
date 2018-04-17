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
    public class ColorInfoDal : DalBase {
        /// <summary>
        /// 获取颜色列表
        /// </summary>
        /// <param name="errText"></param>
        /// <returns></returns>
        public List<ColorInfo> GetEntityList(out string errText, string colorName, bool isExact) {
            errText = "";
            try {
                using (SqlConnection conn = new SqlConnection(SQL_CON)) {
                    conn.Open();
                    var sql = "select * from ColorInfo";
                    if (!string.IsNullOrEmpty(colorName)) {
                        if (isExact) {
                            sql += " where ColorName=@ColorName";
                        } else
                            sql += " where ColorName like '%'+@ColorName+'%'";
                    }
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@ColorName", colorName);
                    SqlDataAdapter ada = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    ada.Fill(dt);
                    conn.Close();
                    var list = DataTableHelper.ToList<ColorInfo>(dt);
                    return list;
                }
            } catch (Exception ex) {
                errText = ex.Message;
                return null;
            }
        }

        /// <summary>
        /// 修改颜色列表
        /// </summary>
        /// <param name="errText"></param>
        /// <param name="colorInfo"></param>
        /// <returns></returns>
        public int UpdateEntity(out string errText, ColorInfo colorInfo) {
            errText = "";
            try {
                using (SqlConnection conn = new SqlConnection(SQL_CON)) {
                    conn.Open();
                    var sql = "update ColorInfo set ColorName=@ColorName,Remark=@Remark where ColorId=@ColorId";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@ColorId", colorInfo.ColorId);
                    cmd.Parameters.AddWithValue("@ColorName", colorInfo.ColorName);
                    cmd.Parameters.AddWithValue("@Remark", colorInfo.Remark);
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
        /// 新增一条颜色信息
        /// </summary>
        /// <param name="errText"></param>
        /// <param name="colorInfo"></param>
        /// <returns></returns>
        public int InsertEntity(out string errText, ColorInfo colorInfo) {
            errText = "";
            try {
                using (SqlConnection conn = new SqlConnection(SQL_CON)) {
                    var sql = "insert into ColorInfo (ColorName,Remark) values(@ColorName,@Remark)";
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@ColorName", colorInfo.ColorName);
                    cmd.Parameters.AddWithValue("@Remark", colorInfo.Remark);
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
        /// 删除一条颜色信息
        /// </summary>
        /// <param name="errText"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteEntity(out string errText, Guid id) {
            errText = "";
            try {
                using (SqlConnection conn = new SqlConnection(SQL_CON)) {
                    conn.Open();
                    var sql = "delete ColorInfo where ColorId=@ColorId";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@ColorId", id);
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
