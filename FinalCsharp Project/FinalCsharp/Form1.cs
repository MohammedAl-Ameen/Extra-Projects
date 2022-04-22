using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace FinalCsharp
{
    public partial class Form1 : Form
    {
        Admin admin;
        bool flag = true;

        public Form1()
        {
            InitializeComponent();
            admin = new Admin();

            groupBox1.Enabled = false;
            groupBox2.Enabled = false;
            groupBox3.Enabled = false;
            groupBox4.Enabled = false;
            groupBox5.Enabled = false;
            groupBox6.Enabled = false;
            groupBox7.Enabled = false;


        }

        private void button1_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = false;
            groupBox2.Enabled = true;
            groupBox3.Enabled = false;
            groupBox4.Enabled = false;
            groupBox5.Enabled = false;
            groupBox7.Enabled = true;
            groupBox6.Enabled = true;

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            flag = false;
            try
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    groupBox7.Enabled = true;
                    groupBox6.Enabled = true;
                    
                    StreamReader reader = new StreamReader(openFileDialog1.FileName);
                    string line = reader.ReadLine();
                    string[] sub = line.Split(' ');


                    line = reader.ReadLine();

                    while (line != null)
                    {
                       
                        sub = line.Split(' ');

                        employee obj1 = new employee(Convert.ToInt32(sub[1]) , sub[0]);
                        comboBox1.Items.Add(sub[1]);
                        admin.AddEmployee(obj1);
                        admin.AddPayroll(Convert.ToInt32(sub[1]) , Convert.ToInt32(sub[2]), Convert.ToDouble(sub[3]), Convert.ToInt32(sub[4]) , Convert.ToDouble(sub[5]));
                        line = reader.ReadLine();
                    }

                    

                    richTextBox1.Text = admin.EmployeeInfo();


                }
            } catch(System.IO.IOException b)
            {

                MessageBox.Show(b.Message);


            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                StreamWriter writer = new StreamWriter(saveFileDialog1.FileName + ".txt");

                flag = true;

                writer.WriteLine(richTextBox1.Text);

                writer.Close();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!flag) {
                string message = "Do you want to close this window?";
                string title = "Close Window";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(message, title, buttons);
                if (result == DialogResult.Yes)
                {
                    this.Close();
                }
                else
                {
                    
                }

            }
            else
            {
                this.Close();

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            employee obj = new employee(Convert.ToInt32(id.Text) , name.Text);
            admin.AddEmployee(obj);
            comboBox1.Items.Add(id.Text);
            richTextBox1.Text = admin.EmployeeInfo();
            MessageBox.Show("The Employee was added");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32( textBox2.Text);
            admin.AddPayroll(id , Convert.ToInt32(textBox4.Text) , Convert.ToDouble(textBox5.Text) , Convert.ToInt32(textBox7.Text) , Convert.ToDouble(textBox6.Text));
            richTextBox1.Text = admin.EmployeeInfo();
        }

        private void Form1_TextChanged(object sender, EventArgs e)
        {

           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = false;
            groupBox2.Enabled = false;
            groupBox3.Enabled = true;
            groupBox4.Enabled = true;
            groupBox5.Enabled = true;
            groupBox7.Enabled = true;
            groupBox6.Enabled = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = true;
            groupBox2.Enabled = false;
            groupBox3.Enabled = false;
            groupBox4.Enabled = false;
            groupBox5.Enabled = false;
            groupBox7.Enabled = true;
            groupBox6.Enabled = true;
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(comboBox1.Text);
            richTextBox2.Text = admin.EmployeeSlip(id);
        }
    }
}
