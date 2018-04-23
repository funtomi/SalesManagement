using DAL;
using SalesManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManagement.BLL {
   public  class ReturnInfoService {
       private StockManageService _stockSrv = new StockManageService();
       private ReturnInfoDal _dal = new ReturnInfoDal();
       private ReturnDetailInfoDal _detailDal = new ReturnDetailInfoDal();
       public int ReturnOrder(out string errText, ReturnInfo info, List<ReturnDetailInfo> details) {
           errText = "";
           if (info==null||details==null||details.Count==0) {
               errText = "退货信息无效！";
               return 0;
           }
           int i = _stockSrv.ReturnOrderManage(out errText, info, details);
           if (i <= 0) {
               return i;
           }
           i = _dal.InsertEntity(out errText,info);
           if (i <= 0) {
               return i;
           }
           i = PurchaseOrderDetail(out errText, details);
           return i;
       }

       private int PurchaseOrderDetail(out string errText, List<ReturnDetailInfo> details) {
           errText = "";
           if (details == null || details.Count == 0) {
               errText = "没有商品信息！";
               return 0;
           }
           int sum = 0;
           foreach (var detail in details) {
               var i = _detailDal.InsertEntity(out errText, detail);
               if (i <= 0) {
                   return i;
               }
               sum++;
           }
           return sum;
       }

       public List<ReturnInfo> QueryAllData(out string errText) {
           return _dal.GetEntityList(out errText);
       }

       public List<ReturnInfo> QueryWithSalesNoAndDate(out string errText, string returnNo, DateTime dateTime1, DateTime dateTime2) {
           return _dal.GetEntityListWithSalesNoAndDate(out errText, returnNo, dateTime1, dateTime2);
       }
   }
}
