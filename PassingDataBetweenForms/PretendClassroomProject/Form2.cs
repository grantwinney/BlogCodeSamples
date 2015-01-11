using System;
using System.Windows.Forms;

namespace MockClassroomProject
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void btnSaveInput_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();

            //form1.???  // How do I show my values on the first form?

            form1.ShowDialog();
        }
    }
}
