﻿using System;
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
         /*   dataGridView1.Refresh();

            dataGridView1.Update();

            dataGridView1.EndEdit();
            dataGridView1.Refresh();*/
            StatusStrip.Text = "Видалено";
        }

       
    }
}