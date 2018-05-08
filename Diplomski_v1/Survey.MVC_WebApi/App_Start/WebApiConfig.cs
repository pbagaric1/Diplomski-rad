using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web;
using System.Web.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Survey.MVC_WebApi.App_Start
{
  public static class WebApiConfig
  {
    public static void Register(HttpConfiguration config)
    {
      // TODO: Add any additional configuration code.
      //var cors = new EnableCorsAttribute("http://localhost:4200", "*", "*");
      //config.EnableCors(cors);

      // Web API routes
      config.MapHttpAttributeRoutes();

      config.Routes.MapHttpRoute(
        name: "DefaultApi",
        routeTemplate: "api/{controller}/{id}",
        defaults: new { id = RouteParameter.Optional }
      );

      // WebAPI when dealing with JSON & JavaScript!
      // Setup json serialization to serialize classes to camel (std. Json format)
      var jsonFormatter = config.Formatters.OfType<JsonMediaTypeFormatter>().First();
      jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

      //ignore loop exception
      config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;

      //hide null properties in json
      jsonFormatter.SerializerSettings = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };
    }
  }
}
