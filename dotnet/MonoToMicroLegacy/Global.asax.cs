using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Newtonsoft.Json.Serialization;
using Swashbuckle.Application;

namespace MonoToMicroLegacy
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();
        }
        
        public class LowercaseContractResolver : DefaultContractResolver
        {
            protected override string ResolvePropertyName(string propertyName)
            {
                return propertyName.ToLower();
            }
        }
        
        protected void Application_Start()
        {
            UnityConfig.RegisterComponents();    
            
            GlobalConfiguration.Configure(config =>
            {                
                config.Formatters.Remove(config.Formatters.XmlFormatter); //removing XML Formatter
                config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new LowercaseContractResolver();
                
                config.EnableSwagger(c => c.SingleApiVersion("Version", "Unicorn Store"))  
                    .EnableSwaggerUi();
                
                config.MapHttpAttributeRoutes();

                config.Routes.MapHttpRoute(
                    name: "DefaultApi",
                    routeTemplate: "api/{controller}/{id}",
                    defaults: new { id = RouteParameter.Optional }
                );
            });
            

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}