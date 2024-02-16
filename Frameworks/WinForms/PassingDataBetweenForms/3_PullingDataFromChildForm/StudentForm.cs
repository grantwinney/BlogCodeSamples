using System;
using System.Windows.Forms;

namespace PullingDataFromChildForm
{
    public partial class StudentForm : Form
    {
        public StudentForm()
        {
            InitializeComponent();
        }

        private void btnGetUserInput_Click(object sender, EventArgs e)
        {
            using (var detailForm = new DetailForm())
            {
                detailForm.ShowDialog();

                SetStudentName(detailForm.Name);
            }
        }

        public void SetStudentName(string name)
        {
            lblStudentName.Text = name;
        }
    }
}
