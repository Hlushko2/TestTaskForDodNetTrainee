using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CopiLibrary;
namespace TestTaskForDodNetTrainee
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MyReader.Read( textBox1.Text,  textBox2.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MyWriter.Write(textBox3.Text, textBox4.Text);
        }
    }
}
