using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RestSharp;

namespace Filter_Github_Api.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult form1(string filter)
        {
            TempData["filter"] = filter;

            return View("Index");

        }

        public ActionResult CustomerJson()
        {
            var client = new RestClient("https://api.github.com/users/" + TempData["filter"] + "/repos");

            var request = new RestRequest(Method.GET);
            request.AddHeader("Accept", "application/json");

            IRestResponse response = client.Execute(request);

            return Content(response.Content);

        }

    }
}