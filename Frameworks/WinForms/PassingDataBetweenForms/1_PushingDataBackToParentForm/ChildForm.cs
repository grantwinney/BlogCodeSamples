using System;
using System.Windows.Forms;

namespace PushingDataBackToParentForm
{
    public partial class ChildForm : Form
    {
        private readonly ParentForm parentForm;

        public ChildForm(ParentForm form)
        {
            InitializeComponent();
            parentForm = form;
        }

        private void btnSaveInput_Click(object sender, EventArgs e)
        {
            parentForm.SetName(txtName.Text);

            parentForm.Age = int.TryParse(txtAge.Text, out var age) ? age : 0;
        }
    }
}
