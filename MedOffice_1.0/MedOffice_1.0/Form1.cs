﻿using System;
using System.Windows.Forms;
using System.Data.OleDb;

namespace MedOffice_1._0
{
    public partial class Main_Menu : Form
    {
        OleDbConnection conn = new OleDbConnection();
        string permission = "";
                
        public Main_Menu()
        {
            InitializeComponent();
            conn.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\xdark\Documents\GitHub\CST-227-CLC-Project\Med_2.mdb;";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

       

        private void loginButton_Click(object sender, EventArgs e)
        {
            string username = usernameBox.Text;
            string password = passwordBox.Text;

            conn.Open();
            OleDbCommand comm = new OleDbCommand();
            comm.Connection = conn;
            comm.CommandText = "SELECT PermissionType FROM Logins WHERE Username= '" 
                + username + "' and Password= '" + password + "'";
            OleDbDataReader reader = comm.ExecuteReader();

            while (reader.Read())
            {
                permission = (reader["PermissionType"].ToString());
            }
            if (permission.Equals("Clerical"))
            {
                MainClerical clerk = new MainClerical();
                clerk.Show();
            }
            else if (permission.Equals(""))
            {
                MessageBox.Show("Incorrect username or password");
            }
                        
            conn.Close();
        }
    }
}
