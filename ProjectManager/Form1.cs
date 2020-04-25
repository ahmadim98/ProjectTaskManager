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
    public partial class Form1 : Form
    {
        private List<Project> projects;
        internal List<Project> Projects { get => projects; set => projects = value; }

        public Form1()
        {
            InitializeComponent();
            projects = new List<Project>();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(listBox1.SelectedIndex == -1)
            {
                return;
            }
            dataGridView1.DataSource = Projects[listBox1.SelectedIndex].TasksData;
            dataGridView2.DataSource = Projects[listBox1.SelectedIndex].ResourcesData;
            dataGridView1.Columns[5].Visible = false;
            dataGridView1.Columns[6].Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.ShowDialog();
            Project pm = new Project(form2.ProjectName);
            Projects.Add(pm);
            updateListbox();
        }

        private void updateListbox()
        {
            listBox1.Items.Clear();
            for (int i = 0; i < Projects.Count; i++)
            {
                listBox1.Items.Add(Projects[i].name);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }


        private void button3_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.ShowDialog();
            if (form3.taskname == null || form3.startdate == null || form3.enddate == null)
            {
                return;
            }
            Task task = new Task(projects.Count.ToString(), form3.taskname, form3.startdate, form3.enddate, null);
            Projects[listBox1.SelectedIndex].createTask(task);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            form4.ShowDialog();
            if (form4.resourcename == null || form4.resourcetype == null || form4.material == null || form4.max == null || form4.standardrate == null || form4.overtime == null || form4.cost == 0)
            {
                return;
            }
            Resources resource = new Resources(form4.resourcename,form4.resourcetype,bool.Parse(form4.material),Convert.ToInt32(form4.max), Convert.ToInt32(form4.standardrate), Convert.ToInt32(form4.overtime),form4.cost);
            Projects[listBox1.SelectedIndex].createResources(resource);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                dataGridView1.Columns[5].Visible = true;

            }else if (checkBox1.Checked == false)
            {
                dataGridView1.Columns[5].Visible = false;
            }
            
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                dataGridView1.Columns[6].Visible = true;

            }
            else if (checkBox2.Checked == false)
            {
                dataGridView1.Columns[6].Visible = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            Projects[listBox1.SelectedIndex].assignResources(dataGridView1.CurrentCell.RowIndex, Convert.ToString(dataGridView2.CurrentRow.Cells[0].Value));
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string resourcename = Convert.ToString(dataGridView1.CurrentRow.Cells[5].Value);
            Projects[listBox1.SelectedIndex].calculateCost(dataGridView1.CurrentCell.RowIndex, resourcename);
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Projects[listBox1.SelectedIndex].totalCost();
        }
    }
}
