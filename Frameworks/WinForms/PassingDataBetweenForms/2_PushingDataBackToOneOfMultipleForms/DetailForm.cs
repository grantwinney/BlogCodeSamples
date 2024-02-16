using System;
using System.Windows.Forms;

namespace PushingDataBackToOneOfMultipleForms
{
    public partial class DetailForm : Form
    {
        private StudentForm studentForm;
        private EmployeeForm employeeForm;
        private SomeClass someClass;

        public DetailForm(StudentForm form)
        {
            InitializeComponent();
            studentForm = form;
        }

        public DetailForm(EmployeeForm form)
        {
            InitializeComponent();
            employeeForm = form;
        }

        public DetailForm(SomeClass someClass)
        {
            InitializeComponent();
            this.someClass = someClass;
        }

        private void btnSaveInput_Click(object sender, EventArgs e)
        {
            if (studentForm != null)
                studentForm.SetStudentName(txtName.Text);
            else if (employeeForm != null)
                employeeForm.EmployeeName = txtName.Text;
            else if (someClass != null)
                someClass.Name = txtName.Text;

            this.Close();
        }
    }
}
