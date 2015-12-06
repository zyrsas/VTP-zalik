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


namespace Edit
{
    public partial class EditForm : Form
    {
        public static int idG;
        public static string nameG;
        public static string cityG;
        public static int yearsG;
        public static string coachG;
        public static string capitanG;

        public EditForm(int id, string name, string city, int year, string coach, string capitan)
        {
            InitializeComponent();

            textBox1.Text = name;
            textBox2.Text = city;
            textBox3.Text = Convert.ToString(year); ;
            textBox4.Text = coach;
            textBox5.Text = capitan;
            idG = id;
            nameG = name;
            cityG = city;
            yearsG = year;
            coachG = coach;
            capitanG = capitan;

         
        }

        private void EditForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            nameG = textBox1.Text;
            cityG = textBox2.Text;
            try
            {
                yearsG = Int32.Parse(textBox3.Text);
            }
            catch
            {
                MessageBox.Show("Помилка!Ви ввели не вірні дані!");
                return;
            }
            coachG = textBox4.Text;
            capitanG = textBox5.Text;



            using (var db = new TeamContext())
            {
                var result = db.Team.SingleOrDefault(b => b.id == idG);
                if (result != null)
                {
                    result.name = nameG;
                    result.years = yearsG;
                    result.city = cityG;
                    result.coach = coachG;
                    result.capitan = capitanG;
                    db.SaveChanges();
                }
            }
            Close();
        }
    }
}
