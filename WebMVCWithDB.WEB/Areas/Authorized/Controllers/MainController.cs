using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebMVCWithDB.WEB.Areas.Authorized.Controllers
{
    public class MainController : Controller
    {
        // GET: Auth/Main
        public ViewResult Index()
        {
            return View();
        }
    }
}