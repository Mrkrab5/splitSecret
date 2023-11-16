using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace splitSecret
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (choiseMethod.SelectedIndex == 0)
                result.Text = thirdMember.Check(entryMassenge.Text);

            else if (choiseMethod.SelectedIndex == 1)
                result.Text = Shamir.Check(entryMassenge.Text);

            else if (choiseMethod.SelectedIndex == 2)
                result.Text = AsmutBlum.Check(entryMassenge.Text);
        }
    }
}
