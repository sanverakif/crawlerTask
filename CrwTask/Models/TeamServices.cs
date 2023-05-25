using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
namespace CrwTask.Models
{
    public class TeamServices
    {

        private readonly string cs = ConfigurationManager.ConnectionStrings ["taskDB"].ConnectionString;
        public SqlConnection con;

        public List<Teams> GetTeams()
        {
            List<Teams> teams = new List<Teams>();
            try {
                using (con = new SqlConnection(cs)) {
                    con.Open();
                    var cmd = new SqlCommand("Select * from Teams", con);
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read()) {
                        Teams t = new Teams();
                        t.ID = Convert.ToInt32(dr ["ID"]);
                        t.Name = dr ["Name"].ToString();
                        t.Logo = dr ["Logo"].ToString();
                        teams.Add(t);
                    }
                }
                return teams.ToList();
            }
            catch (Exception) {
                throw;
            }
        }
    }
    public interface ITeamsService
    {
        List<Teams> GetTeams();
        void AddTeams(Teams item);
        void Delete(Teams item);
        void Update(Teams item);
    }
}