using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;
using FootballTeams;
using System.IO;
using mainForm;

namespace AddTeam
{
    public partial class Form1 : Form
    {
        static string path = "pass.data";
        static int count = 0;

        static string login;
        static string pass;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (!File.Exists(path))
            {
                MessageBox.Show("Not exist");
                using (System.IO.StreamWriter file =
                 new System.IO.StreamWriter(path))
                {
                    file.WriteLine("admin");
                    file.WriteLine("admin");
                }
                login = "admin";
                pass = "admin";
            }
            else
            {
                string[] lines = System.IO.File.ReadAllLines(path);
                login = lines[0];
                pass = lines[1];
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (count == 3)
            {
                MessageBox.Show("Перевищенна кількість спроб введення паролю! Програма завершить свою роботу!");
                Close();
            }

            if ( (textBox1.Text.Equals(login)) && (textBox2.Text.Equals(pass)) )
            {
                this.Hide();
                MainForm myForm = new MainForm();
                myForm.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Помилка! Перевірьте будь ласка дані! І спробуйте ще раз!");
                textBox2.Clear();
                count++;

                countLabel.Text = Convert.ToString(3 - count);
            }
        }
    }
 
}
