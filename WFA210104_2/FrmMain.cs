﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFA210104_2
{
    public partial class FrmMain : Form
    {
        SqlConnection conn;

        public FrmMain()
        {
            //conn = new SqlConnection(
            //    @"Data Source = (localdb)\MSSQLLocalDB; " +
            //    "Initial Catalog = tura;");

            conn = new SqlConnection(
                @"Server=(localdb)\MSSQLLocalDB;" +
                @"AttachDbFilename=|DataDirectory|Resources\tura.mdf");

            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            conn.Open();

            var r = new SqlCommand("SELECT * FROM turazo", conn)
                .ExecuteReader();

            while (r.Read())
            {
                dgvTurazok.Rows.Add(r[0], r[1], r[2], r[3], r[4]);
            }
            conn.Close();

        }
    }
}
