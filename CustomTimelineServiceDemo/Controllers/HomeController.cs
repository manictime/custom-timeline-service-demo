using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;

namespace CustomTimelineServiceDemo.Controllers
{
    public class HomeController : ApiController
    {
        [System.Web.Http.HttpGet]
        public HttpResponseMessage Index()
        {
            var response = new HttpResponseMessage();

            //var s = System.Web.Hosting.HostingEnvironment.MapPath("~/Views/Index.html");
            var content = File.ReadAllText(System.Web.Hosting.HostingEnvironment.MapPath("~/Views/Index.html"));
            response.Content = new StringContent(content);
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("text/html");
            return response;
        }
    }
}
