using System.Web.Optimization;

namespace MafiaGame
{
    public static class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/scripts")
                .IncludeDirectory("~/assets/js/", "*.js")
                .IncludeVendorScripts()
            );

            bundles.Add(new StyleBundle("~/styles")
                .Include("~/assets/css/site.css")
                .IncludeVendorStyles()
            );
        }

        private static Bundle IncludeVendorScripts(this Bundle bundle)
        {
            bundle.Include(
                // Use the development version of Modernizr to develop with and learn from. Then, when you're
                // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
                "~/assets/vendor/modernizr-*",
                "~/assets/vendor/jquery/jquery-{version}.js",
                "~/assets/vendor/jquery/jquery.validate*",
                "~/assets/vendor/bootstrap/js/bootstrap.js"
            );

            return bundle;
        }

        private static Bundle IncludeVendorStyles(this Bundle bundle)
        {
            bundle.Include("~/Assets/Vendor/bootstrap/css/bootstrap.css");

            return bundle;
        }
    }
}
