using System.Web.Optimization;

namespace AmazEng_WAPP
{
    public class BundleConfig
    {
        // For more information on Bundling, visit https://go.microsoft.com/fwlink/?LinkID=303951
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/WebFormsJs").Include(
                            "~/Scripts/WebForms/WebForms.js",
                            "~/Scripts/WebForms/WebUIValidation.js",
                            "~/Scripts/WebForms/MenuStandards.js",
                            "~/Scripts/WebForms/Focus.js",
                            "~/Scripts/WebForms/GridView.js",
                            "~/Scripts/WebForms/DetailsView.js",
                            "~/Scripts/WebForms/TreeView.js",
                            "~/Scripts/WebForms/WebParts.js"));

            // Order is very important for these files to work, they have explicit dependencies
            bundles.Add(new ScriptBundle("~/bundles/MsAjaxJs").Include(
                    "~/Scripts/WebForms/MsAjax/MicrosoftAjax.js",
                    "~/Scripts/WebForms/MsAjax/MicrosoftAjaxApplicationServices.js",
                    "~/Scripts/WebForms/MsAjax/MicrosoftAjaxTimer.js",
                    "~/Scripts/WebForms/MsAjax/MicrosoftAjaxWebForms.js"));

            // Use the Development version of Modernizr to develop with and learn from. Then, when you’re
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                            "~/Scripts/modernizr-*"));

            bundles.Add(new Bundle("~/bundles/bootstrap5").Include(
                           "~/Scripts/bootstrap.js",
                           "~/Scripts/umd/popper.min.js"
                           ));

            bundles.Add(new Bundle("~/bundles/vendors").Include(
                     "~/Assets/vendors/counterup/waypoint.js",
                     "~/Assets/vendors/counterup/jquery.counterup.min.js",
                    "~/Assets/vendors/owl/owl.carousel.min.js",
                    "~/Assets/vendors/isotope/jquery.isotope.js",
                    "~/Assets/vendors/isotope/imagelaoded.min.js",
                    "~/Assets/vendors/animated-headline/animated-headline.js",
                    "~/Assets/vendors/magnific-popup/jquery.magnific-popup.min.js"
                     ));



        }
    }
}