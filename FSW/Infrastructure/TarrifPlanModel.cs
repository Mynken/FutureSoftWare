using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FSW.Infrastructure
{
    public class TarrifPlanModel
    {
        public string Plan { get; set; }

        public IEnumerable<SelectListItem> TariffPlanList
        {
            get
            {
                List<SelectListItem> list = new List<SelectListItem>
                {
                    new SelectListItem { Text = "Сайт-визитка", Value = "Сайт-визитка" },
                    new SelectListItem { Text = "Бизнес - сайт", Value = "Бизнес - сайт" },
                    new SelectListItem { Text = "Сайт компании", Value = "Сайт компании" },
                    new SelectListItem { Text = "Landing Page", Value = "Landing Page" },
                    new SelectListItem { Text = "Custom сайт", Value = "Custom сайт" },
                    new SelectListItem { Text = "Дополнительные услуги", Value = "Дополнительные услуги" },
                    new SelectListItem { Text = "Другое", Value = "Другое" }
                };
                return list.Select(l => new SelectListItem { Selected = (l.Value == Plan), Text = l.Text, Value = l.Value });
            }
        }
    }
}