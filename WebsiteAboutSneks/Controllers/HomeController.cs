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
using WebsiteAboutSneks.DAL;
using WebsiteAboutSneks.Models;
using System.Data.Entity;

namespace WebsiteAboutSneks.Controllers
{
    public class HomeController : Controller
    {
        private SnekContext db = new SnekContext();
        

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Snakes()
        {
            var snakes = db.Snakes.Include(s => s.Breed).Include(s => s.Owner);
            //var snakes = db.Snakes;
            return View(snakes);
        }

        public ActionResult ShowSnake(int id)
        {
            Snake snake = db.Snakes.Find(id);
            return View(snake);
        }
    }
}