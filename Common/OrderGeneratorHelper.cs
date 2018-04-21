using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SalesManagement.Common {
    public static class OrderGeneratorHelper {
        private static string prevBase = string.Empty;//旧的订单号基础部分（精确到秒的字符串）
        private static object orderFormNumberLock = new object();//订单号共享锁
        private static long counter = 1;//订单号累加计数器
        private static string orderNumber = string.Empty;//订单号。
        public static string GetOrderNo() {
            StringBuilder sb = new StringBuilder();
            Monitor.Enter(orderFormNumberLock);
            DateTime now = DateTime.Now;
            #region 短格式，从DateTime.MinValue以来的天数+小时数+分钟数+秒数+1秒内的排序号
            TimeSpan span = now - DateTime.MinValue;
            long tmpDays = span.Days;
            long seconds = span.Hours * 3600 + span.Seconds;
            string newBase = Convert.ToString(tmpDays, 16).PadLeft(5, '0') + Convert.ToString((span.Hours * 3600 + span.Seconds), 16).PadLeft(5, '0');
            if (prevBase != newBase) {
                counter = 1;
                prevBase = newBase;
            }
            sb.Append(newBase + Convert.ToString(counter++, 16).PadLeft(6, '0'));
            #endregion
            #region 长格式，年+月+日+小时+分+秒+订单排序序号
            //string newBase = now.Year.ToString().PadLeft(4, '0') +
            //    now.Month.ToString().PadLeft(2, '0') +
            //    now.Day.ToString().PadLeft(2, '0') +
            //    now.Hour.ToString().PadLeft(2, '0') +
            //    now.Minute.ToString().PadLeft(2, '0') +
            //    now.Second.ToString().PadLeft(2, '0');
            //if (prevBase != newBase) {
            //    //秒数换了则重置计数器
            //    counter = 1;
            //    prevBase = newBase;
            //}
            //sb.Append(newBase + counter.ToString().PadLeft(6, '0'));//只要运行足够快，理论每秒钟可生成99万个单号不重复，至少几千个不会有问题。
            #endregion
            orderNumber = sb.ToString();
            Monitor.Exit(orderFormNumberLock);
            return orderNumber;
        }
    }
}
