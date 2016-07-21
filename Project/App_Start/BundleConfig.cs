using System.Web.Optimization;

namespace Project
{
    public class BundleConfig
    {

        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/node_modules/jquery/dist/jquery.js"));

            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                "~/node_modules/angular/angular.js",
                "~/node_modules/angular-route/angular-route.js",
                "~/node_modules/angular-cookies/angular-cookies.js",
                "~/node_modules/ng-grid/build/ng-grid.js",
                "~/node_modules/angular-ui-grid/ui-grid.js",
                "~/node_modules/ng-dialog/js/ngDialog.js"));

            bundles.Add(new ScriptBundle("~/bundles/main").Include(
                        "~/App/project.js")); // Main Angular Application

            bundles.Add(new ScriptBundle("~/bundles/services").Include(
                        "~/App/service.js"));

            bundles.Add(new ScriptBundle("~/bundles/directives").Include(
                        "~/App/directives.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/node_modules/bootstrap/dist/css/bootstrap.css",
                      "~/Content/site.css",
                      "~/node_modules/ng-grid/ng-grid.css",
                      "~/node_modules/angular-ui-grid/ui-grid.css",
                      "~/node_modules/ng-dialog/css/ngDialog.css",
                      "~/node_modules/ng-dialog/css/ngDialog-theme-default.css"));

        }
    }
}
