using NewsForYou.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static NewsForYou.Model.Model;

namespace NewsForYou.Web.Controllers
{
    public class AgencyListController : Controller
    {
        // GET: AgencyList
        public ActionResult Agency()
        {
            List<AgencyModel> agencies = Business.Business.GetAgencies();
            return View(agencies);
        }
    }
}