using DAL;
using SalesManagement.Model;
using System;
using System.Collections.Generic;
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

    }
}
