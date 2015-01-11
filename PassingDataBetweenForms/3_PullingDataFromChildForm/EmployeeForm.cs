using System;
using System.Windows.Forms;

namespace PullingDataFromChildForm
{
    public partial class EmployeeForm : Form
    {
        public EmployeeForm()
        {
            InitializeComponent();
        }

        private void btnGetUserInput_Click(object sender, EventArgs e)
        {
            using (var detailForm = new DetailForm())
            {
                detailForm.ShowDialog();

                EmployeeName = detailForm.Name;
            }
        }

        public string EmployeeName
        {
            set { lblName.Text = value; }
        }
    }
}
