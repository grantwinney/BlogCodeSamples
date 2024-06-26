﻿using System.Windows.Forms;

namespace PullingDataFromChildForm
{
    public partial class ChildForm : Form
    {
        public ChildForm()
        {
            InitializeComponent();
        }

        public new string Name => txtName.Text;

        public int Age => int.TryParse(txtAge.Text, out int result) ? result : 0;
    }
}
