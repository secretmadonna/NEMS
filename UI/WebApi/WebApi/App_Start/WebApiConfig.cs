﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
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
                routeTemplate: "{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

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
