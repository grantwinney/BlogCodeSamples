using System;
using System.Windows.Forms;

namespace PushingDataBackToParentForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnGetUserInput_Click(object sender, EventArgs e)
        {
            // Notice the 'using' statement. It helps ensure you clean up resources.
            using (var form2 = new Form2(this))
            {
                form2.ShowDialog();
            }
        }

        public void SetName(string name)
        {
            lblName.Text = name;
        }

        public int Age
        {
            set { lblAge.Text = value.ToString(); }
        }
    }
}
