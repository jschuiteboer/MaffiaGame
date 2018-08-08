using System.Web.Optimization;

namespace MafiaGame
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/scripts")
                .IncludeDirectory("~/assets/js/", "*.js")
            );

            bundles.Add(new StyleBundle("~/styles")
                .Include("~/assets/css/site.css")
            );

            bundles.Add(new ScriptBundle("~/scripts/vendor")
                .Include(
                    // Use the development version of Modernizr to develop with and learn from. Then, when you're
                    // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
                    "~/assets/vendor/modernizr-*",
                    "~/assets/vendor/jquery/jquery-{version}.js",
                    "~/assets/vendor/jquery/jquery.validate*",
                    "~/assets/vendor/bootstrap/js/bootstrap.js"
                )
            );

            bundles.Add(new StyleBundle("~/styles/vendor")
                .Include("~/Assets/Vendor/bootstrap/css/bootstrap.css")
            );
        }
    }
}
