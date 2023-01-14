using ClassLibrary1;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : BaseForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            MessageBox.Show("Really?");
        }
    }
}
