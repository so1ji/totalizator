using Ninject;
using Ninject.Modules;
using Ninject.Web.WebApi;
using Ninject.Web.WebApi.Filter;
using Ninject.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Totalizator.Util;
using Newtonsoft.Json;

namespace Totalizator
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);


            NinjectModule registrations = new NinjectRegistrations();
            var kernel = new StandardKernel(registrations);
            kernel.Bind<DefaultFilterProviders>().ToConstant(new DefaultFilterProviders(GlobalConfiguration.Configuration.Services.GetFilterProviders()));
            kernel.Bind<DefaultModelValidatorProviders>().ToConstant(new DefaultModelValidatorProviders(GlobalConfiguration.Configuration.Services.GetModelValidatorProviders()));
            GlobalConfiguration.Configuration.DependencyResolver = new Ninject.Web.WebApi.NinjectDependencyResolver(kernel);
            DependencyResolver.SetResolver(new Ninject.Web.Mvc.NinjectDependencyResolver(kernel));

            JsonConvert.DefaultSettings = () => new JsonSerializerSettings
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            };
        }
    }
}
