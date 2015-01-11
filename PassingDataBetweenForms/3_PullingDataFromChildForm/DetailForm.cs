using System;
using System.Windows.Forms;

namespace PullingDataFromChildForm
{
    public partial class DetailForm : Form
    {
        public DetailForm()
        {
            InitializeComponent();
        }

        public string Name
        {
            get { return txtName.Text; }
        }

        public int Age
        {
            get
            {
                int result;
                Int32.TryParse(txtAge.Text, out result);
                return result;
            }
        }

        // Even this could be removed, if you set this button as the Accept
        //  button on the Form, or set a DialogResult value on the button
        private void btnSaveInput_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
