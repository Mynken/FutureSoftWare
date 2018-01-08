using System.Web;
using System.Web.Optimization;

namespace FSW
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/Scrool").Include(
                         "~/Scripts/Custom/startScrolling.js"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/custom").Include(
                      "~/Scripts/Custom/constellation-calculations.js",
                      "~/Scripts/Custom/constellation-additional.js",
                      "~/Scripts/Custom/constellation-main.js",
                      "~/Scripts/Custom/buttonUp.js",
                      "~/Scripts/Custom/buttonToUp.js",
                      "~/Scripts/Custom/appear.js",
                      "~/Scripts/Custom/appear2.js"));

            bundles.Add(new ScriptBundle("~/bundles/gallery").Include(
                      "~/Scripts/Custom/gallery-index.js",
                      "~/Scripts/Custom/gallery-photoswipe-ui-default.min.js",
                      "~/Scripts/Custom/gallery-photoswipe.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/family.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/AdminContent/css").Include(
                     "~/Content/bootstrap.css",
                      "~/Content/admin.css"));
        }
    }
}
