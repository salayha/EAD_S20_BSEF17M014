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


        // [ActionName("Login")]
        [HttpPost]
        public JsonResult Verify(String login, String password)
        {
            Object data = null;
            var exception = false;
            var url = "";
            var flag = false;
            int res = UserDAO.validateUser(login, password);
            if (res == 1)
            {
                flag = true;
                Session["user"] = login;
                url = Url.Content("~/User/Welcome");
            }
            if (res == -2)
            {
                exception = true;   
            }
            data = new {
                exception1 = exception,
                valid = flag,
                urlToRedirect = url
            };
            return Json(data, JsonRequestBehavior.AllowGet);
        }


        //[ActionName("SignUp")]
        [HttpPost]
        public JsonResult InsertUser(String login, String password, String uname)
        {
            Object data = null;
            var url = "";
            var flag = false;
            var err = "";
            int res = UserDAO.insertUser(login, password, uname);
            if (res == 1)
            {
                flag = true;
                Session["user"] = login;
                ViewBag.user = login;
                url = Url.Content("~/User/Welcome");
            }
            else if (res == -1)
            {
                flag = false;
                err = "Username already exists, try a different one";
            }
            data = new
            {
                valid = flag,
                urlToRedirect = url,
                error = err
            };
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Welcome()
        {
            if (Session["user"] != null)
            {
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
        [HttpPost]
        public JsonResult displayRoots(int parent)
        {
            List<FolderDTO> data= UserDAO.getRoots(parent);
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult NewFolder(string fname, int parent)
        {
            Object data = null;
            int id = UserDAO.makeNewFolder(fname, parent);
            data = new
            {
                fid = id
            };
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}