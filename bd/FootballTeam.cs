using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace FootballTeams
{
    public class FootballTeam
    {
        public int id { get; set; }
        public string name { get; set; }
        public string city { get; set; }
        public int years { get; set; }
        public string coach { get; set; }
        public string capitan { get; set; }
    }

    public class TeamContext : DbContext
    {
        public DbSet<FootballTeam> Team { get; set; }

    }
}
