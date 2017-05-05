using System.Web;
using System.Web.Optimization;

namespace Survey.MVC_WebApi
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new ScriptBundle("~/bundles/app").Include(
                      "~/app/Vendors/angular.js",
                      "~/app/Vendors/angular-ui-router.js",
                      "~/app/Vendors/angular-route.js",
                      "~/app/Vendors/angular-local-storage.js",
                      "~/app/Vendors/ngStorage.js",
                      "~/app/Vendors/md5.js"));

            bundles.Add(new ScriptBundle("~/bundles/surveyApp").Include(
                      "~/app/app.js",
                      "~/app/Controllers/*Controller.js",
                      "~/app/Services/*Service.js"));
        }
    }
}
