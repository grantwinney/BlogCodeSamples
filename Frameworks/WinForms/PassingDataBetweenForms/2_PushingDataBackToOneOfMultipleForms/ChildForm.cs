using System;
using System.Windows.Forms;

namespace PushingDataBackToOneOfMultipleForms
{
    public partial class ChildForm : Form
    {
        private readonly ParentForm1 parentForm1;
        private readonly ParentForm2 parentForm2;

        public ChildForm(ParentForm1 form)
        {
            InitializeComponent();
            parentForm1 = form;
        }

        public ChildForm(ParentForm2 form)
        {
            InitializeComponent();
            parentForm2 = form;
        }

        private void btnSaveInput_Click(object sender, EventArgs e)
        {
            if (parentForm1 != null)
                parentForm1.EmployeeName = txtName.Text;
            else if (parentForm2 != null)
                parentForm2.SetStudentName(txtName.Text);
        }
    }
}
