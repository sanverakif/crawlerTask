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
        TeamServices teamService = new TeamServices();
        public SqlConnection con;

        public ActionResult Index()
        {
            return View(teamService.GetTeams());
        }
        [HttpPost]
        public ActionResult VeriAl(Teams obj)
        {
            connection();
            SqlCommand com = new SqlCommand("Select * from Teams", con);
            com.Parameters.AddWithValue("@ID", obj.ID);
            com.Parameters.AddWithValue("@Name", obj.Name);
            com.Parameters.AddWithValue("@Logo", obj.Logo);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
            return View();
        }
        //[HttpPost]
        //public JsonResult JsonPost(Teams employeeData)
        //{
        //    Teams teams = new Teams
        //    {
        //        ID = employeeData.ID,
        //        Name = employeeData.Name,
        //        Logo = employeeData.Logo
        //    };
        //    return Json(teams, JsonRequestBehavior.AllowGet);
        //}
        public ActionResult IndexDetails(int id)
        {
            var a = teamService.GetTeams();
            var b = a.Where(x => x.ID == id).FirstOrDefault();
            return View(b);
        }

        private void connection()
        {
            string constr = ConfigurationManager.ConnectionStrings ["taskDB"].ConnectionString;
            con = new SqlConnection(constr);
        }

       
    }
}