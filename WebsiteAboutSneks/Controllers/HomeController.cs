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
using WebsiteAboutSneks.DAL;
using WebsiteAboutSneks.Models;
using System.Data.Entity;

namespace WebsiteAboutSneks.Controllers
{
    public class HomeController : Controller
    {
        private SnekContext db = new SnekContext();
        

        //public ActionResult Index()
        //{
        //    return View();
        //}

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

        public ActionResult SnakeQuestions(int id)
        {
            Snake snake = db.Snakes.Find(id);
            var questions = db.Questions.Include(q => q.Snake).Where(q => q.SnakeID == id);

            //Create list of answers and add answers that have corresponding question ids.
            List<Answers> answers = new List<Answers>();
            foreach (Questions question in questions)
            {
                var qa = db.Answers.Where(a => a.QuestionID == question.QuestionID);

                foreach (Answers answer in qa)
                {
                    answers.Add(answer);
                }
            }

            ViewBag.Questions = questions;
            ViewBag.Answers = answers;

            return View(snake);
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

            var currentUser = db.Users.Where(a => a.UserEmail == email).Where(a => a.Password == password);

            //var currentUser = db.Database.SqlQuery<User>(
            //"Select * " +
            //"FROM User " +
            //"WHERE UserEmail = '" + email + "' AND " +
            //"Password = '" + password + "'");

            if (currentUser.Count() > 0)
            {
                FormsAuthentication.SetAuthCookie(email, rememberMe);
                return RedirectToAction("Index", "Home", new { userlogin = email });
            }
            else
            {
                return View();
            }
        }

        //GET: User
        [Authorize]
        public ActionResult Index(String userlogin)
        {
            IEnumerable<User> user = db.Database.SqlQuery<User>(
            "Select User.UserID, User.Password, " +
            "FROM User ");

            ViewBag.Parm = userlogin;

            return View(user);
        }

        /*Hard-coded username and password
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
        */
    }
}