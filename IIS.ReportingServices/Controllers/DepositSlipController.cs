using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IIS.ReportingServices.Controllers
{
    public class DepositSlipController : Controller
    {
        // GET: DepositSlip
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Print(string id, string a)
        {
            return View();
        }
    }
}