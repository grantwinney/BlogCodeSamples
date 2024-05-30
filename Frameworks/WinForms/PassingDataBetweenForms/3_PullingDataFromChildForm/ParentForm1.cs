using System;
using System.Windows.Forms;

namespace PullingDataFromChildForm
{
    public partial class ParentForm1 : Form
    {
        public ParentForm1()
        {
            InitializeComponent();
        }

        private void btnGetUserInput_Click(object sender, EventArgs e)
        {
            using (var childForm = new ChildForm())
            {
                childForm.ShowDialog();

                lblEmployeeName.Text = childForm.Name;
            }
        }
    }
}
