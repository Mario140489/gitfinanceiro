using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Financeiro.Controllers
{
    public class layoutController : Controller
    {
        // GET: layout
        public ActionResult Index()
        {
            return View();
        }
    }
}