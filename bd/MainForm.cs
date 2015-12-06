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
using AddTeam;
using ChangePass;
using About;
using Edit;

namespace mainForm
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
   
        private void MainForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the '_FootballTeams_TeamContextDataSet.FootballTeams' table. You can move, or remove it, as needed.
            this.footballTeamsTableAdapter.Fill(this._FootballTeams_TeamContextDataSet.FootballTeams);
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void addToolStrip_Click(object sender, EventArgs e)
        {
            AddNewTeam addForm = new AddNewTeam();
            addForm.ShowDialog();
            dataGridView1.Update();
            dataGridView1.Refresh();

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = footballTeamsBindingSource;

            // TODO: This line of code loads data into the '_FootballTeams_TeamContextDataSet.FootballTeams' table. You can move, or remove it, as needed.
            this.footballTeamsTableAdapter.Fill(this._FootballTeams_TeamContextDataSet.FootballTeams);

            StatusStrip.Text = "Успішно добавлено";
        }

        private void DeleteToolStrip_Click(object sender, EventArgs e)
        {
            int row = dataGridView1.CurrentCell.RowIndex;
            int id = Int32.Parse(dataGridView1.Rows[row].Cells[0].Value.ToString());
           
            if (id < 0)
            {
                return;
            }

            const string message ="Ви дійсно хочете видалити?";
            const string caption = "Підтвердження видалення";
            var result = MessageBox.Show(message, caption,
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Question);

            // If the no button was pressed ...


            if (result == DialogResult.No)
            {
                StatusStrip.Text = "Готово";
                return;               
            }


            var db = new TeamContext();
            var team = new FootballTeam { id = id };
            db.Team.Attach(team);
            db.Team.Remove(team);
            db.SaveChanges();

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = db.Team.ToList();


            dataGridView1.Refresh();
         
            StatusStrip.Text = "Видалено";
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void змінитиПарольToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangePassword ChangePassForm = new ChangePassword();
            ChangePassForm.ShowDialog();


            StatusStrip.Text = "Пароль змінено";
        }

        private void проПрограмуToolStripMenuItem1_Click(object sender, EventArgs e)
        {
          
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            int row = dataGridView1.CurrentCell.RowIndex;
            int id = Int32.Parse(dataGridView1.Rows[row].Cells[0].Value.ToString());
            
            if (id < 0)
            {
                return;
            }
            
            string name = dataGridView1.Rows[row].Cells[1].Value.ToString();
            string city = dataGridView1.Rows[row].Cells[2].Value.ToString();
            int year = Int32.Parse(dataGridView1.Rows[row].Cells[3].Value.ToString());
            string coach = dataGridView1.Rows[row].Cells[4].Value.ToString();
            string capitan = dataGridView1.Rows[row].Cells[5].Value.ToString();

            EditForm editForm = new EditForm(id, name, city, year, coach, capitan);
            editForm.ShowDialog();

            var db = new TeamContext();
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = db.Team.ToList();

            statusStrip1.Text = "Відредаговано";
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void проПрограмуToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            AboutForm aboutForm = new AboutForm();
            aboutForm.ShowDialog();
        }

        private void вихідToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void toolStripTextBox1_TextChanged(object sender, EventArgs e)
        {

            //MessageBox.Show("event");

                using (var context = new TeamContext())
                {
                    string city = toolStripTextBox1.Text;

                    string sql = String.Format("SELECT * FROM FootballTeams WHERE city LIKE '{0}%'", city);

                   // MessageBox.Show(sql);

                    var blogs = context.Team.SqlQuery(sql).ToList();
                    dataGridView1.DataSource = blogs;
                }
                    

            
        }

        private void exitToolStrip_Click(object sender, EventArgs e)
        {
            Close();
        }

       
    }
}
