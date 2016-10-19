using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication9.Models;

namespace WebApplication9.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {
            using (UserDbContext db = new UserDbContext())
            {
                return View(db.userData.ToList());
            }
           
        }
        public ActionResult Loggin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Loggin(UserData user)
        {
            using (UserDbContext db = new UserDbContext())
            {
                var usr = db.userData.Where(u => u.firstName == user.firstName && u.password == user.password).FirstOrDefault();
              if(usr == null)
                {
                    ModelState.AddModelError("", "Passowrd or email is wrong");

                }
                else
                {
                    
                    Session["UserId"] = user.UserId.ToString();
                    Session["FirstName"] = user.firstName.ToString();
                    return RedirectToAction("Logged");
                }
               
            }
            return View();
        }
        public ActionResult Logged()
        {
            if(Session["UserId"] != null)
            {
                return View();

            }
            else
            {
                
                return RedirectToAction("Loggin");
            }
            
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(UserData account)
        {
            if (ModelState.IsValid)
            {
                using (UserDbContext db = new UserDbContext())
                {
                    db.userData.Add(account);
                    db.SaveChanges();
                }
                ModelState.Clear();
                ViewBag.message = "Account is success";
            }
            return View();
        }
    }
}