using System;
using System.Windows.Forms;

namespace PushingDataBackToOneOfMultipleForms
{
    public partial class EmployeeForm : Form
    {
        public EmployeeForm()
        {
            InitializeComponent();
        }

        private void btnGetUserInput_Click(object sender, EventArgs e)
        {
            // Notice the 'using' statement. It helps ensure you clean up resources.
            using (var form2 = new DetailForm(this))
            {
                form2.ShowDialog();
            }
        }

        public string EmployeeName
        {
            set { lblName.Text = value; }
        }
    }
}
