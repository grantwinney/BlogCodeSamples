using System;
using System.Windows.Forms;

namespace PushingDataBackToOneOfMultipleForms
{
    public partial class ParentForm1 : Form
    {
        public ParentForm1()
        {
            InitializeComponent();
        }

        private void btnGetUserInput_Click(object sender, EventArgs e)
        {
            using (var childForm = new ChildForm(this))
            {
                childForm.ShowDialog();
            }
        }

        public string EmployeeName
        {
            set { lblName.Text = value; }
        }
    }
}
