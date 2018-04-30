using DAL;
using SalesManagement.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManagement.BLL {
    public class SalesInfoService {
        private SalesDetailInfoDal _detailDal = new SalesDetailInfoDal();
        private SalesInfoDal _dal = new SalesInfoDal();
        private StockManageService _stockSrv = new StockManageService();

        public int SalesOrder(out string errText, Model.SalesInfo salesInfo, List<Model.SalesDetailInfo> details) {
            errText = "";
            var i = _stockSrv.SalesOrderManage(out errText, salesInfo, details);
            if (i <= 0) {
                return i;
            }
            i = _dal.InsertEntity(out errText, salesInfo);
            if (i <= 0) {
                return i;
            }
            i = PurchaseOrderDetail(out errText, details);

            return i;
        }

        private int PurchaseOrderDetail(out string errText, List<SalesDetailInfo> details) {
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


        public List<SalesClientInfo> QuerySalesInfo(out string errText, DateTime startDate, DateTime endDate) {
            return _detailDal.GetEntityList(out errText, startDate, endDate);
        }

        public List<SalesClientInfo> QueryDataWithCommodityNo(out string errText, string commodityNo, DateTime startDt, DateTime endDt) {
            return _detailDal.GetEntityListWithCommodityNo(out errText, commodityNo, startDt, endDt);
        }

        public List<SalesClientInfo> QueryDataWithSalesNo(out string errText, string salesNo, DateTime startDt, DateTime endDt) {
            return _detailDal.GetEntityListWithSalesNo(out errText, salesNo, startDt, endDt);
        }

        public List<SalesInfo> QueryAllData(out string errText) {
            return _dal.GetEntityList(out errText);
        }

        public List<SalesInfo> QueryWithSalesNoAndDate(out string errText, string salesNo, DateTime dateTime1, DateTime dateTime2) {
            return _dal.GetEntityListWithSalesNoAndDate(out errText, salesNo,dateTime1,dateTime2);
        }

        public DataTable GetDailySalesStatistic(out string errText, DateTime dateTime) {
            var startDt = DateTime.Parse(dateTime.ToString("yyyy-MM-dd") + " 00:00:00");
            var endDt = DateTime.Parse(dateTime.ToString("yyyy-MM-dd") + " 23:59:59");
            return _dal.GetStatisticData(out errText, startDt, endDt);
        }

        public DataTable GetMonthSalesStatistic(out string errText, DateTime dateTime) {
            var startDt = dateTime.AddDays(1 - dateTime.Day);
            var endDt = dateTime.AddDays(1 - dateTime.Day).AddMonths(1).AddDays(-1);  
            return _dal.GetStatisticData(out errText, startDt, endDt);
        }

        public DataTable GetDetailsByDocNo(out string errText, Guid id) {
            return _dal.GetEntityList(out errText, id);
        }
    }
}
