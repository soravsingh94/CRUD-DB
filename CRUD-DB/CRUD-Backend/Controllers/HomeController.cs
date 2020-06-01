using CRUD_Backend.Models;
using DAL;
using DAL.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUD_Backend.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICommandHandler _commandHandler;
        public HomeController()
        {
            _commandHandler = new DbCommandHandler();
        }
        public ActionResult Index()
        {
            var abc = _commandHandler.ExecuteStoredProcedureList<Employee>("dbo.USP_Employee_Get").ToList();
            ViewBag.Title = "Home Page";

            return View();
        }
    }
}
