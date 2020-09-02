using AdminMaster.UI.Filters;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminMaster.UI.Controllers
{
    [AuthenticateFilter]
    public class HomeController : Controller
    {
        public IInvCollectionRepository Repository { get; }
        public HomeController(IInvCollectionRepository repository)
        {
            Repository = repository;
        }
        // GET: Home
        public ActionResult Index()
        {
            var list = Repository.Inventory_Collects.OrderByDescending(p => p.lastdt).Skip(10).Take(10);
            return View();
        }
    }
}