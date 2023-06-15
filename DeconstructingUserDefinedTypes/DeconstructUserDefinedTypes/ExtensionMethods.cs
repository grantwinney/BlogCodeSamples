using System.Drawing;

namespace DeconstructUserDefinedTypes
{
    public static class ExtendedPoint
    {
        public static void Deconstruct(this Point p, out int x, out int y)
        {
            x = p.X;
            y = p.Y;
        }
    }

    public static class ExtendedSize
    {
        public static void Deconstruct(this Size s, out int w, out int h)
        {
            w = s.Width;
            h = s.Height;
        }
    }
}
