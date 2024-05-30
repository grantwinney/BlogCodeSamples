using System;
using System.Windows.Forms;

namespace PullingDataFromChildForm
{
    public partial class ParentForm2 : Form
    {
        public ParentForm2()
        {
            InitializeComponent();
        }

        private void btnGetUserInput_Click(object sender, EventArgs e)
        {
            using (var childForm = new ChildForm())
            {
                childForm.ShowDialog();

                lblStudentName.Text = childForm.Name;
                lblAge.Text = childForm.Age.ToString();
            }
        }
    }
}
