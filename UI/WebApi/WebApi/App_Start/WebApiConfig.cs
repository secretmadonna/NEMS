using Newtonsoft.Json;
using System.Web.Http;

namespace SecretMadonna.NEMS.UI.WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API 配置和服务

            // Web API 路由
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            var jsonFormatter = config.Formatters.JsonFormatter;

            config.Formatters.JsonFormatter.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
            //var xml = config.Formatters.XmlFormatter;
            //var dcs = new DataContractSerializer();
            //xml.SetSerializer()
            //config.Formatters.FormUrlEncodedFormatter;

            //config.Filters.Add(new CustomAuthorizationFilterAttribute());
            config.Filters.Add(new CustomActionFilterAttribute());
            config.Filters.Add(new CustomExceptionFilterAttribute());
        }
    }
}