﻿using DAL;
using SalesManagement.Model;
using System;
using System.Collections.Generic;

namespace SalesManagement.BLL {
    public class UserInfoService {
        private UserInfoDal dal = new UserInfoDal();

        /// <summary>
        /// 查询用户
        /// </summary>
        /// <param name="errText"></param>
        /// <returns></returns>
        public List<UserInfo> GetEntityList(out string errText) {
            return dal.GetEntityList(out errText,"",false);
        }

        /// <summary>
        /// 模糊查询用户
        /// </summary>
        /// <param name="errText"></param>
        /// <returns></returns>
        public List<UserInfo> QueryUserInfo(out string errText,string userName) {
            return dal.GetEntityList(out errText,userName,false);
        }

        /// <summary>
        /// 精确查找用户
        /// </summary>
        /// <param name="errText"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        public List<UserInfo> ExactQueryUserInfo(out string errText, string userName) {
            return dal.GetEntityList(out errText, userName, true);
        }
        /// <summary>
        /// 修改用户
        /// </summary>
        /// <param name="errText"></param>
        /// <param name="userInfo"></param>
        /// <returns></returns>
        public int UpdateEntity(out string errText, UserInfo userInfo) {
            return dal.UpdateEntity(out errText, userInfo);
        }

        /// <summary>
        /// 新增用户
        /// </summary>
        /// <param name="errText"></param>
        /// <param name="userInfo"></param>
        /// <returns></returns>
        public int InsertEntity(out string errText, UserInfo userInfo) {
            return dal.InsertEntity(out errText, userInfo);
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="errText"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteEntity(out string errText, Guid id) {
            return dal.DeleteEntity(out errText, id);
        }

        /// <summary>
        /// 获取登录的用户信息
        /// </summary>
        /// <param name="errText"></param>
        /// <param name="userName"></param>
        /// <param name="passWord"></param>
        /// <returns></returns>
        public UserInfo GetLoginUserInfo(out string errText,string userName,string passWord) {
            errText = "";
            var result = dal.GetEntityList(out errText, userName, passWord);
            if (result==null||result.Count==0) {
                return null;
            }
            return result[0];
        }

        public String GetUserNameById(out string errText, Guid userId) {
            return dal.GetEntityList(out errText, userId);
        }
        
    }
}
