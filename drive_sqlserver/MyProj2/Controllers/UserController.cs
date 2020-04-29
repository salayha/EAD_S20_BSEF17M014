using DAL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace MyProj.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        [HttpGet]
        public ActionResult Login()
        {
            ViewBag.MSG = TempData["err"];
            return View();
        }
        [HttpPost]
        public JsonResult SetSession(String login)
        {
            if (login!=null)
            {
                Session["user"] = login;
               
                var data = new
                {
                    success = true
                };
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var data = new
                {
                    success = false
                };
                return Json(data, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult Welcome()
        {
            if (Session["user"] != null)
            {
                var login = Session["user"];
                ViewBag.usr = Session["user"];
                
                return View();
            }
            else
            {
                TempData["err"] = "Unauthorized Access";
                return Redirect("Login");
            }
        }
        public ActionResult SignUp()
        {
            return View();
        }
        
        
    }
}