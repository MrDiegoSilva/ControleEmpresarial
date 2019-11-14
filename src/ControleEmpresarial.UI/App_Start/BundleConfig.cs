using System.Web.Optimization;

namespace ControleEmpresarial.UI
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            // App Styles
            bundles.Add(new StyleBundle("~/Content/appCss").Include(
                "~/Content/app/css/app.css",
                "~/Content/mvc-override.css"
            ));

            // Bootstrap Styles
            bundles.Add(new StyleBundle("~/Content/bootstrapCss").Include(
                "~/Content/app/css/bootstrap.css", new CssRewriteUrlTransform()
            ));

            bundles.Add(new ScriptBundle("~/bundles/Angle").Include(
                    // App init
                    "~/Scripts/app/app.init.js",
                    // Modules
                    "~/Scripts/app/modules/bootstrap-start.js",
                    "~/Scripts/app/modules/calendar.js",
                    "~/Scripts/app/modules/classyloader.js",
                    "~/Scripts/app/modules/clear-storage.js",
                    "~/Scripts/app/modules/constants.js",
                    "~/Scripts/app/modules/flatdoc.js",
                    "~/Scripts/app/modules/trigger-resize.js",
                    "~/Scripts/app/modules/fullscreen.js",
                    "~/Scripts/app/modules/gmap.js",
                    "~/Scripts/app/modules/load-css.js",
                    "~/Scripts/app/modules/localize.js",
                    "~/Scripts/app/modules/maps-vector.js",
                    "~/Scripts/app/modules/navbar-search.js",
                    "~/Scripts/app/modules/notify.js",
                    "~/Scripts/app/modules/now.js",
                    "~/Scripts/app/modules/panel-tools.js",
                    "~/Scripts/app/modules/play-animation.js",
                    "~/Scripts/app/modules/porlets.js",
                    "~/Scripts/app/modules/sidebar.js",
                    "~/Scripts/app/modules/skycons.js",
                    "~/Scripts/app/modules/slimscroll.js",
                    "~/Scripts/app/modules/sparkline.js",
                    "~/Scripts/app/modules/table-checkall.js",
                    "~/Scripts/app/modules/toggle-state.js",
                    "~/Scripts/app/modules/utils.js",
                    "~/Scripts/app/modules/chart.js",
                    "~/Scripts/app/modules/morris.js",
                    "~/Scripts/app/modules/rickshaw.js",
                    "~/Scripts/app/modules/chartist.js",
                    "~/Scripts/app/modules/tour.js",
                    "~/Scripts/app/modules/sweetalert.js",
                    "~/Scripts/app/modules/color-picker.js",
                    "~/Scripts/app/modules/imagecrop.js",
                    "~/Scripts/app/modules/chart-knob.js",
                    "~/Scripts/app/modules/chart-easypie.js",
                    "~/Scripts/app/modules/select2.js"
                ));

            // Main Vendor
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Scripts/jquery-2.2.4.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                "~/Scripts/jquery.validate*",
                "~/Scripts/jquery.unobtrusive-ajax.js",
                "~/Scripts/methods_pt.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryajax").Include(
                "~/Scripts/jquery.unobtrusive-ajax.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                "~/Scripts/modernizr-*"
            ));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                "~/Scripts/bootstrap.js"
            ));

            // Demos
            bundles.Add(new ScriptBundle("~/bundles/demoDatatable").Include(
                "~/Scripts/demo/demo-datatable.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/demoFlot").Include(
                "~/Scripts/demo/demo-flot.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/demoJQGrid").Include(
                "~/Scripts/demo/demo-jqgrid.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/demoPanels").Include(
                "~/Scripts/demo/demo-panels.js"
            ));


            // Vendor Plugins
            bundles.Add(new StyleBundle("~/bundles/animatecss").Include(
                "~/Vendor/animate.css/animate.min.css"
            ));

            bundles.Add(new ScriptBundle("~/bundles/matchMedia").Include(
                "~/Vendor/matchMedia/matchMedia.js"
            ));

            bundles.Add(new StyleBundle("~/bundles/fontawesome").Include(
                "~/Vendor/fontawesome/css/font-awesome.min.css", new CssRewriteUrlTransform()
            ));

            bundles.Add(new StyleBundle("~/bundles/whirl").Include(
                "~/Vendor/whirl/dist/whirl.css"
            ));

            bundles.Add(new StyleBundle("~/bundles/simpleLineIcons").Include(
                "~/Vendor/simple-line-icons/css/simple-line-icons.css", new CssRewriteUrlTransform()
            ));

            bundles.Add(new ScriptBundle("~/bundles/storage").Include(
                "~/Vendor/jQuery-Storage-API/jquery.storageapi.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryEasing").Include(
                "~/Vendor/jquery.easing/js/jquery.easing.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/animo").Include(
                "~/Vendor/animo.js/animo.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/slimscroll").Include(
                "~/Vendor/slimscroll/jquery.slimscroll.min.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/screenfull").Include(
                "~/Vendor/screenfull/dist/screenfull.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/localize").Include(
                "~/Vendor/jquery-localize-i18n/dist/jquery.localize.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/sparklines").Include(
                "~/Vendor/sparkline/index.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/flot").Include(
                "~/Vendor/flot/jquery.flot.js",
                "~/Vendor/flot.tooltip/js/jquery.flot.tooltip.min.js",
                "~/Vendor/flot/jquery.flot.resize.js",
                "~/Vendor/flot/jquery.flot.pie.js",
                "~/Vendor/flot/jquery.flot.time.js",
                "~/Vendor/flot/jquery.flot.categories.js",
                "~/Vendor/flot-spline/js/jquery.flot.spline.min.js"
            ));

            bundles.Add(new StyleBundle("~/bundles/SweetAlertCss").Include(
                "~/Vendor/sweetalert/dist/sweetalert.css"
            ));

            bundles.Add(new StyleBundle("~/bundles/SweetAlert").Include(
                "~/Vendor/sweetalert/dist/sweetalert.min.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/moment").Include(
                "~/Vendor/moment/min/moment-with-locales.min.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/jqGrid").Include(
                "~/Vendor/jqgrid/js/jquery.jqGrid.js",
                "~/Vendor/jqgrid/js/i18n/grid.locale-en.js"
            ));

            bundles.Add(new StyleBundle("~/bundles/jqGridCss").Include(
                "~/Vendor/jqgrid/css/ui.jqgrid.css",
                "~/Vendor/jquery-ui/themes/smoothness/jquery-ui.css"
            ));

            bundles.Add(new ScriptBundle("~/bundles/typeaheadJs").Include(
                "~/Vendor/typeahead/js/typeahead.bundle.js",
                "~/Vendor/typeahead/js/typeahead.mvc.model.js"
            ));

            bundles.Add(new StyleBundle("~/bundles/typeaheadCss").Include(
                "~/Vendor/typeahead/css/typeahead.css"
            ));

            bundles.Add(new ScriptBundle("~/bundles/datatables").Include(
                "~/Vendor/datatables/media/js/jquery.dataTables.min.js",
                "~/Vendor/datatables-colvis/js/dataTables.colVis.js",
                "~/Vendor/datatables/media/js/dataTables.bootstrap.js",
                // Buttons
                "~/Vendor/datatables-buttons/js/dataTables.buttons.js",
                "~/Vendor/datatables-buttons/js/buttons.bootstrap.js",
                "~/Vendor/datatables-buttons/js/buttons.colVis.js",
                "~/Vendor/datatables-buttons/js/buttons.flash.js",
                "~/Vendor/datatables-buttons/js/buttons.html5.js",
                "~/Vendor/datatables-buttons/js/buttons.print.js",
                "~/Vendor/datatables-responsive/js/dataTables.responsive.js",
                "~/Vendor/datatables-responsive/js/responsive.bootstrap.js"
            ));

            bundles.Add(new StyleBundle("~/bundles/datatablesCss")
                .Include("~/Vendor/datatables-colvis/css/dataTables.colVis.css", new CssRewriteUrlTransform())
                .Include("~/Vendor/datatables/media/css/dataTables.bootstrap.css", new CssRewriteUrlTransform())
                .Include("~/Vendor/dataTables.fontAwesome/index.css", new CssRewriteUrlTransform())
            );

            bundles.Add(new ScriptBundle("~/bundles/parsley").Include(
                "~/Vendor/parsleyjs/dist/parsley.min.js"
            ));

            bundles.Add(new StyleBundle("~/bundles/Spinkit").Include(
                "~/Vendor/spinkit/css/spinkit.css"
            ));

            bundles.Add(new StyleBundle("~/bundles/LoadersCss").Include(
                "~/Vendor/loaders.css/loaders.css"
            ));

            bundles.Add(new StyleBundle("~/bundles/MorrisCss").Include(
                "~/Vendor/morris.js/morris.css"
            ));

            bundles.Add(new ScriptBundle("~/bundles/Morris").Include(
                "~/Vendor/raphael/raphael.js",
                "~/Vendor/morris.js/morris.js"
            ));
        }
    }
}
