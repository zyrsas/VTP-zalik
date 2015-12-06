using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChangePass
{
    public partial class ChangePassword : Form
    {
        static string path = "pass.data";

        public ChangePassword()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (System.IO.StreamWriter file =
               new System.IO.StreamWriter(path))
            {
                file.WriteLine(textBox1.Text);
                file.WriteLine(textBox2.Text);
            }
            Close();
        }
    }
}
