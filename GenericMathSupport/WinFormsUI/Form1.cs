using GenericMathSupport.Example3;

namespace MathSupportUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCombine_Click(object sender, EventArgs e)
        {
            var swatch1 = new ColorSwatch("Yellow", new List<Color>
                {
                    Color.LightYellow,    // 255,255,224
                    Color.Goldenrod,      // 218,165, 32
                    Color.DarkGoldenrod,  // 184,134, 11
                }
          );

            var swatch2 = new ColorSwatch("Blue", new List<Color>
                {
                    Color.AliceBlue,      // 240,248,255
                    Color.DodgerBlue,     //  30,144,255
                    Color.Navy,           //   0,  0,128
                }
             );

            var mixedSwatches = swatch1 * swatch2;

            flowLayoutPanel1.Controls.Add(new Label { Text = swatch1.Name });
            foreach (var color in swatch1.Shades)
                flowLayoutPanel1.Controls.Add(new Label { BackColor = color });

            flowLayoutPanel2.Controls.Add(new Label { Text = swatch2.Name });
            foreach (var color in swatch2.Shades)
                flowLayoutPanel2.Controls.Add(new Label { BackColor = color });

            flowLayoutPanel3.Controls.Add(new Label { Text = "Mixed" });
            foreach (var color in mixedSwatches)
                flowLayoutPanel3.Controls.Add(new Label { BackColor = color });
        }
    }
}