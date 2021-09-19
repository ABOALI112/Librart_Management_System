﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Librart_Management_System
{
    public partial class Rolecs : Form
    {
        public Rolecs()
        {
            InitializeComponent();
        }

        private void Rolecs_Load(object sender, EventArgs e)
        {
            CreateNewData();
        }
        void UpdateRecords()
        {
            Connection connection = new();
            SqlCommand sql = new("update Role_Master where '" + Role_id_textbox.Text +"'", connection.ActiveConection());
            sql.ExecuteNonQuery();
        }
        private void Update_Button_Click(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void New_Button_Click(object sender, EventArgs e)
        {
          
            CreateNewData();
            ViewDataInGrid();


        }
        
        void CreateNewData()
        {
            Role_id_textbox.Clear();
            Role_Name_txtbx.Clear();
            status_cmbbx.SelectedItem = -1;

            Connection connection = new();
            SqlDataAdapter sqlData = new ("USR_ROLE", connection.ActiveConection());
            sqlData.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable data = new();
            sqlData.Fill(data);
            Role_id_textbox.Text = data.Rows[0][0].ToString();
            Role_Name_txtbx.Focus();
        }
        void AddNewRecords()
        {
            Connection connection = new();
            SqlCommand sql = new("insert into Role_Master values('"+Role_id_textbox.Text+"''"+Role_Name_txtbx.Text+"''"+status_cmbbx.Text+"'", connection.ActiveConection());
            sql.ExecuteNonQuery();
        }

        private void Save_button_Click(object sender, EventArgs e)
        {
            AddNewRecords();
            Role_Name_txtbx.Clear();
            Role_id_textbox.Clear();
            status_cmbbx.SelectedItem = -1;
            MessageBox.Show("Saved","Done",MessageBoxButtons.OK,MessageBoxIcon.Information);
            CreateNewData();
            ViewDataInGrid();
        }
        void ViewDataInGrid()
        {
            Connection connection = new();
            SqlDataAdapter adapter = new("Select * from Role_Master",connection.ActiveConection());
            DataTable dt = new();
            adapter.Fill(dt);
            Role_Grid_view.Rows.Clear();
            foreach (DataRow row in dt.Rows)
            {
                int dtb = Role_Grid_view.Rows.Add();
                Role_Grid_view.Rows[dtb].Cells[1].Value = (dtb + 1).ToString();
               Role_Grid_view.Rows[dtb].Cells[1].Value = row["Role_ID"].ToString();
                Role_Grid_view.Rows[dtb].Cells[2].Value = row["Role"].ToString();
                Role_Grid_view.Rows[dtb].Cells[3].Value = row["Role_Status"].ToString();


            }
        }
    }
}
