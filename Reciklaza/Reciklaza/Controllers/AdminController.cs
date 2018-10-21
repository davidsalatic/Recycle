using Reciklaza.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Reciklaza.Controllers
{
    public class AdminController : Controller
    {

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Authorize(Reciklaza.Data.Models.Admin adminModel)
        {
            using (ReciklazaContext db = new ReciklazaContext())
            {
                var adminDetails = db.Admins.Where(x => x.Username == adminModel.Username && x.Password == adminModel.Password).FirstOrDefault();
                if (adminDetails == null)
                {
                    adminModel.LoginErrorMessage = "Nije dobar username ili password.";
                    return View("Login", adminModel);
                }
                else
                {
                    Session["Id"] = adminDetails.Id;
                    return RedirectToAction("Index", "Home");
                }
            }
        }

        public ActionResult LogOut()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }
    }
}