using DAL;
using SalesManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManagement.BLL {
    public class StockManageService {
        private StockInfoDal _stockInfoDal = new StockInfoDal();
        private StockDetailInfoDal _stockDetailInfoDal = new StockDetailInfoDal();
        /// <summary>
        /// 库存进货
        /// </summary>
        /// <param name="errText"></param>
        /// <param name="purchaseDocInfo"></param>
        /// <param name="details"></param>
        /// <returns></returns>
        public int PurchaseOrderManage(out string errText, Model.PurchaseDocInfo purchaseDocInfo, List<Model.PurchaseDetailDocInfo> details) {
            errText = "";
            var warehouseId = purchaseDocInfo.WarehouseId;
            if (purchaseDocInfo == null || details == null || details.Count == 0) {
                errText = "信息不足，采购失败！";
                return 0;
            }
            int sum = 0;
            foreach (var commodity in details) {
                sum += commodity.Count;

            }
            var list = _stockInfoDal.GetEntityList(out errText, warehouseId, true);
            if (list == null || list.Count == 0) {
                return 0;
            }
            var info = list[0];
            if (info.Capacity - info.Count < sum) {
                errText = "仓库容量不足!";
                return 0;
            }
            foreach (var item in details) {
                var i = SaveStockDetailInfo(out errText, warehouseId, item.CommodityId, item.Count, item.Remark);
                if (i <= 0) {
                    return i;
                }
            }
            return 1;
        }

        /// <summary>
        /// 保存库存明细（加库存）
        /// </summary>
        /// <param name="errText"></param>
        /// <param name="warehouseId"></param>
        /// <param name="commodityId"></param>
        /// <param name="count"></param>
        /// <param name="remark"></param>
        /// <returns></returns>
        private int SaveStockDetailInfo(out string errText, Guid warehouseId, Guid commodityId, int count, string remark) {
            errText = "";
            if (warehouseId == Guid.Empty || commodityId == Guid.Empty || count == 0) {
                errText = "无效信息！";
                return 0;
            }
            var list = _stockDetailInfoDal.GetEntityList(out errText, warehouseId, commodityId);
            int i = 0;
            if (list == null || list.Count == 0) {
                StockDetailInfo info = new StockDetailInfo() { CommodityId = commodityId, WarehouseId = warehouseId, Count = count, Remark = remark };
                i = _stockDetailInfoDal.InsertEntity(out errText, info);

            } else {
                var info2 = list[0];
                info2.Count += count;
                i = _stockDetailInfoDal.UpdateEntity(out errText, info2);
            }
            if (i <= 0) {
                return i;
            }
            var stock = _stockInfoDal.GetEntityList(out errText, warehouseId, true);
            if (stock == null || stock.Count == 0) {
                return 0;
            }
            var info3 = stock[0];
            info3.Count += count;
            i = _stockInfoDal.UpdateEntity(out errText, info3);
            return i;
        }

        public StockDetailClientInfo GetCommdityWarehouse(out string errText, Guid commodityId) {
            return _stockDetailInfoDal.GetCommodityStock(out errText, commodityId);
        }

        public int SalesOrderManage(out string errText, SalesInfo salesInfo, List<SalesDetailInfo> details) {
            errText = "";
            if (salesInfo == null || details == null || details.Count == 0) {
                errText = "信息不足，销售单保存失败！";
                return 0;
            }
            foreach (var commodity in details) {
                var warehouse = commodity.WarehouseId;
                var list = _stockDetailInfoDal.GetEntityList(out errText, warehouse, commodity.CommodityId);
                if (list == null || list.Count == 0) {
                    errText = "没有库存信息！";
                    return 0;
                }
                var stock = list[0];
                if (stock.Count < commodity.Count) {
                    errText = string.Format("商品{0}库存不足，当前库存{1}", commodity.CommodityId, stock.Count);
                    return 0;
                }
            }
            foreach (var commodity in details) {
                var i = SaveSalesStockInfo(out errText, commodity.WarehouseId, commodity.CommodityId, commodity.Count, commodity.Remark);
                if (i <= 0) {
                    return i;
                }
            }
            return 1;
        }

        /// <summary>
        /// 减库存
        /// </summary>
        /// <param name="errText"></param>
        /// <param name="warehouseId"></param>
        /// <param name="commodityId"></param>
        /// <param name="count"></param>
        /// <param name="remark"></param>
        /// <returns></returns>
        private int SaveSalesStockInfo(out string errText, Guid warehouseId, Guid commodityId, int count, string remark) {
            errText = "";
            if (warehouseId == Guid.Empty || commodityId == Guid.Empty || count == 0) {
                errText = "无效信息！";
                return 0;
            }
            var list = _stockDetailInfoDal.GetEntityList(out errText, warehouseId, commodityId);
            int i = 0;
            if (list == null || list.Count == 0) {
                errText = "没有库存！";
                return 0;
            } else {
                var info = list[0];
                info.Count -= count;
                i = _stockDetailInfoDal.UpdateEntity(out errText, info);
            }
            if (i <= 0) {
                return i;
            }
            var stock = _stockInfoDal.GetEntityList(out errText, warehouseId, true);
            if (stock == null || stock.Count == 0) {
                return 0;
            }
            var info3 = stock[0];
            info3.Count -= count;
            i = _stockInfoDal.UpdateEntity(out errText, info3);
            return i;
        }

        public int ReturnOrderManage(out string errText, ReturnInfo info, List<ReturnDetailInfo> details) {
            errText = "";
            if (info == null || details == null || details.Count == 0) {
                errText = "信息不足，退货失败！";
                return 0;
            } 
            foreach (var commodity in details) {
                var list = _stockInfoDal.GetEntityList(out errText, commodity.WarehouseId, true);
                if (list == null || list.Count == 0) {
                    return 0;
                }
                var com = list[0];
                if (com.Capacity - com.Count<commodity.Count) {
                    errText = "仓库容量不足!";
                    return 0;
                }
            }
           
            foreach (var item in details) {
                var i = SaveStockDetailInfo(out errText, item.WarehouseId, item.CommodityId, item.Count,"");
                if (i <= 0) {
                    return i;
                }
            }
            return 1;
        }
    }
}
