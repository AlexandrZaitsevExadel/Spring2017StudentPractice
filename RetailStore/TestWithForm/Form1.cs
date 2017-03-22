using System;
using System.Windows.Forms;
using DBase.Domain.Services;
using DBase.Domain.Models;


namespace TestWithForm
{
    public partial class Form1 : Form
    {
        private readonly IStoreService _serviceClass;
        private Accessory _accessory;

        public Form1(IStoreService sc)
        {
            _serviceClass = sc;
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = _serviceClass.GetAccessories();
            dataGridView1.AutoGenerateColumns = true;
        }

        
        private void button1_Click(object sender, EventArgs e)
        {
            _accessory = new Accessory(Convert.ToInt32(textBox1.Text), textBox2.Text, Convert.ToInt32(textBox3.Text));
            _serviceClass.CreateAccessory(_accessory);
            dataGridView1.DataSource = _serviceClass.GetAccessories();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            _serviceClass.DeleteAccessory(Convert.ToInt32(textBox1.Text));
            dataGridView1.DataSource = _serviceClass.GetAccessories();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _accessory = new Accessory(Convert.ToInt32(textBox1.Text), textBox2.Text, Convert.ToInt32(textBox3.Text));
            _serviceClass.UpdateAccessory(_accessory);
            dataGridView1.DataSource = _serviceClass.GetAccessories();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
