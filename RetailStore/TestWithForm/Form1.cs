using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using DBase.Domain.Services;
using DBase.Domain.Models;


namespace TestWithForm
{
    public partial class Form1 : Form
    {
        static string connectionStringName = "TestWithForm.Properties.Settings.Setting";
        IStoreService serviceClass;
        DataSet accessoryDataSet = new DataSet();
        private AccessoryTable _accessoryTable;

        public Form1(IStoreService sc)
        {
            serviceClass = sc;
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DataSet accessoryDataSet = serviceClass.Read();
            dataGridView1.DataSource = accessoryDataSet.Tables[0];
            dataGridView1.AutoGenerateColumns = true;
        }

        
        private void button1_Click(object sender, EventArgs e)
        {
            _accessoryTable = new AccessoryTable(Convert.ToInt32(textBox1.Text), textBox2.Text, Convert.ToInt32(textBox3.Text));
            serviceClass.Create(_accessoryTable);
            dataGridView1.DataSource = serviceClass.Read().Tables[0];
        }

        private void button3_Click(object sender, EventArgs e)
        {
            serviceClass.Delete(Convert.ToInt32(textBox1.Text));
            dataGridView1.DataSource = serviceClass.Read().Tables[0];
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _accessoryTable = new AccessoryTable(Convert.ToInt32(textBox1.Text), textBox2.Text, Convert.ToInt32(textBox3.Text));
            serviceClass.Update(_accessoryTable);
            dataGridView1.DataSource = serviceClass.Read().Tables[0];
        }
    }
}
