using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Edit
{
    public partial class EditForm : Form
    {
       /* public static int id;
        public static string name;
        public static string city;
        public static int years;
        public static string coach;
        public static string capitan;*/

        public EditForm(int id, string name, string city, int year, string coach, string capitan)
        {
            InitializeComponent();

            textBox1.Text = name;
            textBox2.Text = city;
            textBox3.Text = Convert.ToString(year); ;
            textBox4.Text = coach;
            textBox5.Text = capitan;
         
        }

        private void EditForm_Load(object sender, EventArgs e)
        {

        }
    }
}
