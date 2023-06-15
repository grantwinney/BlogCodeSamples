using System.Drawing;

namespace DeconstructUserDefinedTypes
{
    internal class Furniture
    {
        public string Name { get; set; }
        public Point Location { get; set; }
        public Size Size { get; set; }
        public Room Room { get; set; }
    }

    internal class Room
    {
        public string Name { get; set; }
        public int Floor { get; set; }
        public Size Size { get; set; }
    }
}
