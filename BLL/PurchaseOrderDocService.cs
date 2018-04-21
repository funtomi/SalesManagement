using DAL;
using SalesManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManagement.BLL {
    public class PurchaseOrderDocService {

        private PurchaseDocInfoDal _dal = new PurchaseDocInfoDal();
        private PurchaseDetailDocInfoDal _detailDal = new PurchaseDetailDocInfoDal();
        private StockManageService _stockSrv = new StockManageService();
        public int PurchaseOrder(out string errText, PurchaseDocInfo purchaseDocInfo, List<PurchaseDetailDocInfo> details) {
            errText = "";
            var i=_stockSrv.PurchaseOrderManage(out errText, purchaseDocInfo, details);
            if (i <= 0) {
                return i;
            }
            i = _dal.InsertEntity(out errText, purchaseDocInfo);
            if (i<=0) {
                return i;
            }
            i= PurchaseOrderDetail(out errText,details);
            
            return i;
        }

        private int PurchaseOrderDetail(out string errText, List<PurchaseDetailDocInfo> details) {
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
