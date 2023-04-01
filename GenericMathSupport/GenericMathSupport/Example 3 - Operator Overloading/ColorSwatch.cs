using System.Drawing;
using System.Numerics;

namespace GenericMathSupport.Example3
{
    public class ColorSwatch
    {
        public IEnumerable<Color> Shades { get; }
        public string Name { get; private set; }

        public ColorSwatch(string name, IEnumerable<Color> shades)
        {
            Name = name;
            Shades = shades.ToList();
        }

        public static IList<Color> operator +(ColorSwatch cs1, ColorSwatch cs2) =>
           cs1.Shades.Concat(cs2.Shades).ToList();

        public static IList<Color> operator *(ColorSwatch cs1, ColorSwatch cs2)
        {
            var colorMatrix = new List<Color>();
            var amount = 0.5;

            foreach (var s1 in cs1.Shades)
            {
                foreach (var s2 in cs2.Shades)
                {
                    // Thank you Timwi.. stackoverflow.com/a/3722337
                    byte r = (byte)(s1.R * amount + s2.R * (1 - amount));
                    byte g = (byte)(s1.G * amount + s2.G * (1 - amount));
                    byte b = (byte)(s1.B * amount + s2.B * (1 - amount));
                    colorMatrix.Add(Color.FromArgb(r, g, b));
                }
            }

            return colorMatrix;
        }
    }
}
