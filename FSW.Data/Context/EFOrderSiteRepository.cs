using FSW.Data.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FSW.Data.Entities;

namespace FSW.Data.Context
{
    public class EFOrderSiteRepository : IOrderSiteRepository
    {
        FSWContext context = new FSWContext();
        public IEnumerable<OrderSite> OrderSites
        {
            get
            {
                using (var context = new FSWContext())
                {
                    return context.OrderSites.Where(x => x.isCheked == false).ToList();
                }
            }
        }
        public IEnumerable<OrderSite> OrderAll
        {
            get
            {
                using (var context = new FSWContext())
                {
                    return context.OrderSites.Where(x => x.isCheked == true).ToList();
                }
            }
        }
        public OrderSite FindOrder(int Id)
        {
            using (var context = new FSWContext())
            {
                var dbEntry = context.OrderSites.Find(Id);
                return dbEntry;
            }
        }
        public void SaveSiteOrder(OrderSite orderSite)
        {
            using (var context = new FSWContext())
            {
                if (orderSite.id == 0)
                    context.OrderSites.Add(orderSite);
                else
                {
                    OrderSite dbEntry = context.OrderSites.Find(orderSite.id);
                    if (dbEntry != null)
                    {
                        dbEntry.Name = orderSite.Name;
                        dbEntry.Surname = orderSite.Surname;
                        dbEntry.Phone = orderSite.Phone;
                        dbEntry.Email = orderSite.Email;
                        dbEntry.TariffPlan = orderSite.TariffPlan;
                        dbEntry.Notes = orderSite.Notes;
                        dbEntry.isCheked = orderSite.isCheked;
                    }
                }
                context.SaveChanges();
            }
        }
    }
}
