using CrwTask.Models;
using Newtonsoft.Json;
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
        TeamServices TeamService = new TeamServices();
        public SqlConnection con;

        public ActionResult Index()
        {
            return View(TeamService.GetTeams());
        }
        public ActionResult TeamDetails(int id)
        {
            var a = TeamService.GetTeams();
            var b = a.Where(x => x.ID == id).FirstOrDefault();
            return View(b);
        }
        [HttpPost]
        public ActionResult AddTeam(Teams obj)
        {
            Connection();
            SqlCommand com = new SqlCommand($"Insert INTO Teams (Name,Logo) VALUES ('{obj.Name}', '{obj.Logo}')", con);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
            return View();
        }
  
        public ActionResult IndexDetails(int id)
        {
            var a = TeamService.GetTeams();
            var b = a.Where(x => x.ID == id).FirstOrDefault();
            return View(b);
        }

        private void Connection()
        {
            string constr = ConfigurationManager.ConnectionStrings ["taskDB"].ConnectionString;
            con = new SqlConnection(constr);
        }


    }
}