using System.Drawing;
using System.Numerics;

namespace GenericMathSupport
{
    public class ColorSwatch : IAdditionOperators<ColorSwatch, ColorSwatch, IList<Color>>
    {
        private readonly IEnumerable<Color> shades;
        public string Name { get; private set; }

        public ColorSwatch(string name, IEnumerable<Color> shades)
        {
            Name = name;
            this.shades = shades.ToList();
        }

        public static IList<Color> operator +(ColorSwatch cs1, ColorSwatch cs2) =>
           cs1.shades.Concat(cs2.shades).ToList();

        public static IList<Color> operator *(ColorSwatch cs1, ColorSwatch cs2)
        {
            var colorMatrix = new List<Color>();

            foreach (var s1 in cs1.shades)
            {
                foreach (var s2 in cs2.shades)
                {
                    var a = s1.A + (s2.A * (255 - s1.A) / 255);
                    var r = ((s1.R * s1.A) + (s2.R * s2.A * (255 - s1.A) / 255)) / a;
                    var g = ((s1.G * s1.A) + (s2.G * s2.A * (255 - s1.A) / 255)) / a;
                    var b = ((s1.B * s1.A) + (s2.B * s2.A * (255 - s1.A) / 255)) / a;

                    colorMatrix.Add(Color.FromArgb(a, r, g, b));
                }
            }

            return colorMatrix;
        }
    }
}
