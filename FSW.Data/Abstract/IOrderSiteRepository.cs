using FSW.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSW.Data.Abstract
{
    public interface IOrderSiteRepository
    {
        IEnumerable<OrderSite> OrderSites { get; }
        IEnumerable<OrderSite> OrderAll { get; }
        void SaveSiteOrder(OrderSite orderSite);
        OrderSite FindOrder(int Id);
    }
}
