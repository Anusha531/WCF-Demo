﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WcfWebClient.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            var myService = new CourseReference.CourseServiceClient("DefaultEndpoint");
            myService.ClientCredentials.UserName.UserName = "Anusha";
            myService.ClientCredentials.UserName.Password = "Anusha";

            var returnValue = myService.GetAll();
            ViewBag.Message = returnValue.Count();

            return View();
        }

        public ActionResult Contact()
        {
            var myService = new CourseReference.CourseServiceClient("DefaultEndpoint");
            myService.ClientCredentials.UserName.UserName = "Anusha";
            myService.ClientCredentials.UserName.Password = "Anusha";

            var returnValue = myService.Get(2021);
            ViewBag.Message = returnValue.Title;

            return View();
        }
    }
}