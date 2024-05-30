using System;
using System.Windows.Forms;

namespace PushingDataBackToParentForm
{
    public partial class ParentForm : Form
    {
        public ParentForm()
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

        public void SetName(string name)
        {
            lblName.Text = name;
        }

        public int Age
        {
            set { lblAge.Text = value.ToString(); }
        }
    }
}
