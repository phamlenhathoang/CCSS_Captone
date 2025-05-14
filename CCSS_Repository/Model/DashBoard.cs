using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSS_Repository.Model
{
    public class AccountDasboard
    {

    }
    public enum DateFilterType
    {
        Today,
        ThisWeek,
        ThisMonth,
        ThisYear
    }
    public enum RevenueSource
    {
        Order,
        festival,
        Service,
        Total
    }
    public class ContractCount
    {
        public int Hour { get; set; }  // 0 to 23
        public int Day { get; set; }   // 1 to 31
        public int Month { get; set; }   // 1 to 12
        public int Count { get; set; }
    }
  
}
