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
                           "~/Scripts/bootstrap.bundle.min.js"
                           ));

            bundles.Add(new Bundle("~/bundles/vendors").Include(
                     "~/Assets/vendors/counterup/counterup2.min.js",
                    "~/Assets/vendors/owl/owl.carousel.min.js",
                    "~/Assets/vendors/isotope/jquery.isotope.js",
                    "~/Assets/vendors/isotope/imagelaoded.min.js",
                    "~/Assets/vendors/animated-headline/animated-headline.js",
                    "~/Assets/vendors/magnific-popup/jquery.magnific-popup.min.js"
                     ));

            bundles.Add(new Bundle("~/admin/bundles/core").Include(
                    "~/AdminPages/Assets/js/Admin.js",
                    "~/AdminPages/Assets/vendors/@popperjs/core/dist/umd/popper.min.js",
                   "~/AdminPages/Assets/vendors/bootstrap/dist/js/bootstrap.min.js",
                   "~/AdminPages/Assets/vendors/volt/volt.js"
                    ));


            bundles.Add(new Bundle("~/admin/bundles/vendors").Include(
                   "~/AdminPages/Assets/vendors/onscreen/dist/on-screen.umd.min.js",
                   "~/AdminPages/Assets/vendors/nouislider/distribute/nouislider.min.js",
                   "~/AdminPages/Assets/vendors/smooth-scroll/dist/smooth-scroll.polyfills.min.js",
                   "~/AdminPages/Assets/vendors/chartist/dist/chartist.min.js",
                   "~/AdminPages/Assets/vendors/chartist-plugin-tooltips/dist/chartist-plugin-tooltip.min.js",
                   "~/AdminPages/Assets/vendors/vanillajs-datepicker/dist/js/datepicker.min.js",
                   "~/AdminPages/Assets/vendors/sweetalert2/dist/sweetalert2.all.min.js",
                    "~/AdminPages/Assets/vendors/moment/moment.min.js",
                   "~/AdminPages/Assets/vendors/notyf/notyf.min.js",
                   "~/AdminPages/Assets/vendors/simplebar/dist/simplebar.min.js",
                   "~/AdminPages/Assets/vendors/buttons/buttons.js"
                    ));

        }
    }
}