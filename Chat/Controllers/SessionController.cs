using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Chat.Controllers
{
    public class SessionController : Controller
    {
        public ActionResult SetUser(string id, string name)
        {
            Session["uid"] = id;
            Session["uname"] = name;
            return Json(new { success = true });
        }
        public ActionResult getUser()
        {
            if (Session["uid"] != null && Session["uname"] != null)
            {
                var user = new {id = Session["uid"], name = Session["uname"] };
                return Json(new { success = true, user = user }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { success = false }, JsonRequestBehavior.AllowGet);
        }
    }
}