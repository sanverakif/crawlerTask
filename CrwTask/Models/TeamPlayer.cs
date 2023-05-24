using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrwTask.Models
{
    public class TeamPlayer
    {
        public int ID { get; set; }
        public Teams TeamID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
}