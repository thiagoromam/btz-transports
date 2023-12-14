using System.Web.Optimization;

namespace BtzTransports.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Scripts/jquery-{version}.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                "~/Scripts/jquery.validate*"
            ));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                "~/Scripts/modernizr-*"
            ));

            bundles.Add(new Bundle("~/bundles/bootstrap").Include(
                "~/Scripts/bootstrap.js"
            ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/bootstrap.css",
                "~/Content/toastr.css",
                "~/Content/site.css"
            ));

            bundles.Add(new ScriptBundle("~/bundles/messages").Include(
                "~/Scripts/sweetalert.min.js",
                "~/Scripts/toastr.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                "~/Scripts/angular.js",
                "~/Scripts/app/api-service.js",
                "~/Scripts/app/app.js",
                "~/Scripts/app/messages.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/site").Include(
                "~/Scripts/app/enums.js"
            ));

            // apis
            bundles.Add(new ScriptBundle("~/bundles/api/contas").Include("~/Scripts/api/contas.js"));
            bundles.Add(new ScriptBundle("~/bundles/api/usuarios").Include("~/Scripts/api/usuarios.js"));
            bundles.Add(new ScriptBundle("~/bundles/api/motoristas").Include("~/Scripts/api/motoristas.js"));
            bundles.Add(new ScriptBundle("~/bundles/api/veiculos").Include("~/Scripts/api/veiculos.js"));

            // conta
            bundles.Add(new ScriptBundle("~/bundles/conta/login").Include("~/Scripts/conta/login.js"));

            // usuario
            bundles.Add(new ScriptBundle("~/bundles/usuario/index").Include("~/Scripts/usuario/index.js"));
            bundles.Add(new ScriptBundle("~/bundles/usuario/editar").Include("~/Scripts/usuario/editar.js"));

            // motorista
            bundles.Add(new ScriptBundle("~/bundles/motorista/index").Include("~/Scripts/motorista/index.js"));
            bundles.Add(new ScriptBundle("~/bundles/motorista/editar").Include("~/Scripts/motorista/editar.js"));

            // veiculos
            bundles.Add(new ScriptBundle("~/bundles/veiculo/index").Include("~/Scripts/veiculo/index.js"));
            bundles.Add(new ScriptBundle("~/bundles/veiculo/editar").Include("~/Scripts/veiculo/editar.js"));
        }
    }
}
