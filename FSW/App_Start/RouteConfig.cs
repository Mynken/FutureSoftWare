using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace FSW
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapMvcAttributeRoutes();

            routes.MapRoute(
             name: "Gallery",
             url: "Gallery/Page/{page}",
             defaults: new { controller = "Home", action = "Gallery" }
         );
            routes.MapRoute(
             name: "Feedback",
             url: "Feedback/Page/{page}",
             defaults: new { controller = "Home", action = "Feedback" }
         );
            routes.MapRoute(
               name: "QuestionIndex",
               url: "Page{page}",
               defaults: new { controller = "AdminManage", action = "QuestionIndex" }
           );
            routes.MapRoute(
               name: "OrderSiteAll",
               url: "Page{page}",
               defaults: new { controller = "AdminManage", action = "OrderSiteAll" }
           );
            routes.MapRoute(
               name: "FeedbackAll",
               url: "Page{page}",
               defaults: new { controller = "AdminManage", action = "FeedbackAll" }
           );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
