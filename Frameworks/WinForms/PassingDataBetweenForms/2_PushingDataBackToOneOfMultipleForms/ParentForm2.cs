using System;
using System.Windows.Forms;

namespace PushingDataBackToOneOfMultipleForms
{
    public partial class ParentForm2 : Form
    {
        public ParentForm2()
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

        public void SetStudentName(string name)
        {
            lblStudentName.Text = name;
        }
    }
}
