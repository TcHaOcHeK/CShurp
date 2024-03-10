using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_1_WindowsForm
{
    public partial class Form3 : Form
    {
        public void LeaveInForm2()
        {
            Form2 fr2 = new Form2();
            fr2.Show();
            this.Close();
        }

        public void AddDLL( int setting = 1)
        {
            
        }
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddDLL();//extern отправка
            LeaveInForm2();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            AddDLL(2);
            LeaveInForm2();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            AddDLL(3);
            LeaveInForm2();
        }

       
    }
}
