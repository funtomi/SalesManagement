using SalesManagement.Common;
using SalesManagement.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL {
   public class UserInfoDal:DalBase { 
       /// <summary>
       /// 获取用户列表
       /// </summary>
       /// <param name="errText"></param>
       /// <returns></returns>
       public List<UserInfo> GetEntityList(out string errText, string userName,bool isExact) {
           errText = "";
           try {
               using (SqlConnection conn = new SqlConnection(SQL_CON)) {
                   conn.Open();
                   var sql = "select * from UserInfo";
                   if (!string.IsNullOrEmpty(userName)) {
                       if (isExact) {
                           sql += " where UserName=@UserName";
                       } else
                           sql += " where UserName like '%'+@UserName+'%'";
                   }
                   SqlCommand cmd = new SqlCommand(sql, conn);
                   cmd.Parameters.AddWithValue("@UserName",userName);
                   SqlDataAdapter ada = new SqlDataAdapter(cmd);
                   DataTable dt = new DataTable();
                   ada.Fill(dt);
                   conn.Close();
                   var list = DataTableHelper.ToList<UserInfo>(dt);
                   return list;
               }
           } catch (Exception ex) {
               errText = ex.Message;
               return null;
           }
       }

       /// <summary>
       /// 修改用户列表
       /// </summary>
       /// <param name="errText"></param>
       /// <param name="userInfo"></param>
       /// <returns></returns>
       public int UpdateEntity(out string errText,UserInfo userInfo) {
           errText = "";
           try {
               using (SqlConnection conn= new SqlConnection(SQL_CON)) {
                   conn.Open();
                   var sql = "update UserInfo set UserName=@UserName,Password=@Password,Permission=@Permission,Remark=@Remark where Id=@Id";
                   SqlCommand cmd = new SqlCommand(sql, conn);
                   cmd.Parameters.AddWithValue("@Id", userInfo.Id);
                   cmd.Parameters.AddWithValue("@UserName", userInfo.UserName);
                   cmd.Parameters.AddWithValue("@Password", userInfo.Password);
                   cmd.Parameters.AddWithValue("@Permission", userInfo.Permission);
                   cmd.Parameters.AddWithValue("@Remark", userInfo.Remark);
                   var i =cmd.ExecuteNonQuery();
                   conn.Close();
                   return i;
               }
           } catch (Exception ex) {
               errText = ex.Message;
               return 0;
           }
       }

       /// <summary>
       /// 新增一条用户信息
       /// </summary>
       /// <param name="errText"></param>
       /// <param name="userInfo"></param>
       /// <returns></returns>
       public int InsertEntity(out string errText, UserInfo userInfo) {
           errText = "";
           try {
               using (SqlConnection conn= new SqlConnection(SQL_CON)) {
                   var sql = "insert into UserInfo (UserName,Password,Permission,Remark) values(@UserName,@Password,@Permission,@Remark)";
                   conn.Open();
                   SqlCommand cmd = new SqlCommand(sql, conn);
                   cmd.Parameters.AddWithValue("@UserName", userInfo.UserName);
                   cmd.Parameters.AddWithValue("@Password", userInfo.Password);
                   cmd.Parameters.AddWithValue("@Permission", userInfo.Permission);
                   cmd.Parameters.AddWithValue("@Remark", userInfo.Remark);
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
       /// 删除一条用户信息
       /// </summary>
       /// <param name="errText"></param>
       /// <param name="id"></param>
       /// <returns></returns>
       public int DeleteEntity(out string errText, Guid id) {
           errText = "";
           try {
               using (SqlConnection conn = new SqlConnection(SQL_CON)) {
                   conn.Open();
                   var sql = "delete UserInfo where Id=@Id";
                   SqlCommand cmd = new SqlCommand(sql, conn);
                   cmd.Parameters.AddWithValue("@Id", id); 
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
       /// 获取用户信息列表
       /// </summary>
       /// <param name="errText"></param>
       /// <param name="userName">用户名</param>
       /// <param name="password">密码</param>
       /// <returns></returns>
       public List<UserInfo> GetEntityList(out string errText, string userName, string password) {
           errText = "";
           try {
               using (SqlConnection conn = new SqlConnection(SQL_CON)) {
                   conn.Open();
                   var sql = "select * from UserInfo where UserName=@UserName and Password=@Password";
                   SqlCommand cmd = new SqlCommand(sql, conn);
                   cmd.Parameters.AddWithValue("@UserName", userName);
                   cmd.Parameters.AddWithValue("@Password", password);
                   SqlDataAdapter ada = new SqlDataAdapter(cmd);
                   DataTable dt = new DataTable();
                   ada.Fill(dt);
                   conn.Close();
                   var list = DataTableHelper.ToList<UserInfo>(dt);
                   return list; 
               }
           } catch (Exception ex) {
               errText = ex.Message;
               return null;
           }
       }
       /// <summary>
       /// 根据id获取名称
       /// </summary>
       /// <param name="errText"></param>
       /// <param name="userId"></param>
       /// <returns></returns>
       public string GetEntityList(out string errText, Guid userId) {
           errText = "";
           try {
               using (SqlConnection conn = new SqlConnection(SQL_CON)) {
                   conn.Open();
                   var sql = "select UserName from UserInfo where Id=@Id";
                   SqlCommand cmd = new SqlCommand(sql, conn);
                   cmd.Parameters.AddWithValue("@Id", userId);
                   var result =cmd.ExecuteScalar();
                   conn.Close();
                   if (result == null) {
                       return null;
                   }
                   return result.ToString();
               }
           } catch (Exception ex) {
               errText = ex.Message;
               return null;
           }
       }
   }
}
