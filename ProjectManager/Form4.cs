using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectManager
{
    public partial class Form4 : Form
    {
        public string resourcename;
        public string resourcetype;
        public string material;
        public string max;
        public string standardrate;
        public string overtime;
        public int cost;

        public Form4()
        {
            InitializeComponent();
            comboBox1.Items.Add("True");
            comboBox1.Items.Add("False");
            comboBox2.Items.Add("Work");
            comboBox2.Items.Add("Product");
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.resourcename = textBox1.Text;
            this.resourcetype = comboBox2.SelectedItem.ToString();
            this.material = comboBox1.SelectedItem.ToString();
            this.max = textBox4.Text;
            this.standardrate = textBox5.Text;
            this.overtime = textBox6.Text;
            this.cost = int.Parse(textBox7.Text);
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
