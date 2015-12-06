using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FootballTeams;

namespace AddTeam
{
    public partial class AddNewTeam : Form
    {
        public AddNewTeam()
        {
            InitializeComponent();
        }

        private void AddNewTeam_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var db = new TeamContext())
            {
                var team = new FootballTeam { };
                team.name = textBox1.Text;
                team.city = textBox2.Text;
                team.years = Int32.Parse(textBox3.Text);
                team.coach = textBox4.Text;
                team.capitan = textBox5.Text;
                db.Team.Add(team);
                db.SaveChanges();

                // Display all Blogs from the database 
                var query = from b in db.Team
                            orderby b.name
                            select b;                
            }
            Close();
        }
    }
}
