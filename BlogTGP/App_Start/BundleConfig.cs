﻿using System.Web;
using System.Web.Optimization;

namespace BlogTGP
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
                        "~/Content/site.css",
                        "~/Content/zocial.css"
                        ));



            bundles.Add(new ScriptBundle("~/bundles/revolution").Include(
                        "~/revolution/js/jquery.themepunch.revolution.min.js",
                        "~/revolution/js/jquery.themepunch.tools.min.js",
                        "~/revolution/js/extensions/revolution.extension.slideanims.min.js",
                        "~/revolution/js/extensions/revolution.extension.layeranimation.min.js",
                        "~/revolution/js/extensions/revolution.extension.navigation.min.js",
                        "~/revolution/js/extensions/revolution.extension.parallax.min.js"
                        ));

        }
    }
}
