/*
 IS 403 Section 002
 Team Snek: Andrew Dale, Nate Turner, Matt Smith, Chelsia Liu
 Created on 11/9/18
 */

 /*
 This Home controller was created by Nate Turner
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebsiteAboutSneks.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Snakes()
        {
            return View();
        }
    }
}