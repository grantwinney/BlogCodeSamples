using System;
using System.Windows.Forms;

namespace PushingDataBackToParentForm
{
    public partial class Form2 : Form
    {
        private Form1 form1;

        public Form2(Form1 form1)
        {
            InitializeComponent();
            this.form1 = form1;
        }

        private void btnSaveInput_Click(object sender, EventArgs e)
        {
            form1.SetName(txtName.Text);

            int age;
            if (int.TryParse(txtAge.Text, out age))
                form1.Age = age;

            this.Close();
        }
    }
}
