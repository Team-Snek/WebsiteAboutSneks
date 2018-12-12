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
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebsiteAboutSneks.Models;

namespace WebsiteAboutSneks.Controllers
{
    public class HomeController : Controller
    {
        //Create list of snake objects.
        public List<Snake> liSnakes = new List<Snake>();

        public void AddSnakes()
        {
            //liSnakes.Add(new Snake(1, "Artemis", "Nate", "Corn snake", "4 years", "This girl is sassy, but super sweet!", "/Content/images/artemis.jpg"));
            //liSnakes.Add(new Snake(2, "Athena", "Kelly", "Corn snake", "4 years", "This girl is soooo snuggly!", "/Content/images/athena.jpg"));
            //liSnakes.Add(new Snake(3, "Midas", "Nate & Kelly", "Corn snake", "1 year", "Tiny, cute butter noodle.", "/Content/images/midas.jpg"));
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Snakes()
        {
            if (liSnakes.Count == 0)
            {
                AddSnakes();
            }
            ViewBag.SnakeList = liSnakes;

            return View();
        }

        public ActionResult ShowSnake(string id)
        {
            if (liSnakes.Count == 0)
            {
                AddSnakes();
            }

            //Iterate through list to find matching snake.
            //int iCount = 0;
            foreach (Snake snek in liSnakes)
            {
                //iCount++;
                //if (snek.snakeID == Convert.ToInt32(id))
                //{
                //    ViewBag.Snek = snek;
                //    break;
                //}
            }

            return View();
        }
        
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(FormCollection form, bool rememberMe = false)
        {
            String email = form["Email address"].ToString();
            String password = form["Password"].ToString();

            if (string.Equals(email, "greg@test.com") && (string.Equals(password, "greg")))
            {
                FormsAuthentication.SetAuthCookie(email, rememberMe);

                return RedirectToAction("Index", "Home");

            }
            else
            {
                return View();
            }
        }
    }
}