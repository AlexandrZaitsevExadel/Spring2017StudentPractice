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


namespace TestWithForm
{
    public partial class Form1 : Form
    {
        StockService serviceClass = new StockService();
        Database db = DatabaseFactory.CreateDatabase("TestWithForm.Properties.Settings.Setting");
        DataSet accessoryDataSet = new DataSet();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DataSet accessoryDataSet = serviceClass.read(db);
            dataGridView1.DataSource = accessoryDataSet.Tables[0];
            dataGridView1.AutoGenerateColumns = true;
        }

        
        private void button1_Click(object sender, EventArgs e)
        {
            serviceClass.create(db, Convert.ToInt32(textBox1.Text), textBox2.Text, Convert.ToInt32(textBox3.Text));
            dataGridView1.DataSource = serviceClass.read(db).Tables[0];
        }

        private void button3_Click(object sender, EventArgs e)
        {
            serviceClass.delete(db, Convert.ToInt32(textBox1.Text));
            dataGridView1.DataSource = serviceClass.read(db).Tables[0];
        }

        private void button2_Click(object sender, EventArgs e)
        {
            serviceClass.update(db, Convert.ToInt32(textBox1.Text), textBox2.Text, Convert.ToInt32(textBox3.Text));
            dataGridView1.DataSource = serviceClass.read(db).Tables[0];
        }
    }
}
