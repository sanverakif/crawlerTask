using CrwTask.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CrwTask.Controllers
{
    public class HomeController : Controller
    {
        public readonly ITeamsService _teamsService;
        public HomeController(ITeamsService teamsService)
        {
            _teamsService = teamsService;
        }
        [HttpGet]
        public ActionResult Index()
        {
            AllModels mo = new AllModels();
            mo.Teams = _teamsService.GetTeams().ToList();
            return View(mo);     
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}