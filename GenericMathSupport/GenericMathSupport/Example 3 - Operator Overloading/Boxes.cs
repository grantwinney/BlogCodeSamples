namespace GenericMathSupport.Example3
{
    /******************************
     * EMPLOYEE REPORT CLASS
     *  w/ INTERFACE
     * ****************************/

    public interface IBox
    {
        int Width { get; }
        int Height { get; }
        int Depth { get; }
    }

    public class Box : IBox
    {
        public Box(int width, int height, int depth)
        {
            Width = width;
            Height = height;
            Depth = depth;
        }

        public int Width { get; private set; }
        public int Height { get; private set; }
        public int Depth { get; private set; }

        public int Area { get => Width * Height * Depth; }

        public static Box operator +(Box box1, Box box2)
        {
            var widestWidth = Math.Max(box1.Width, box2.Width);
            var deepestDepth = Math.Max(box1.Depth, box2.Depth);
            var combinedHeight = box1.Height + box2.Height;

            return new Box(widestWidth, combinedHeight, deepestDepth);
        }

        public static bool operator ==(Box box1, Box box2)
            => box1.Width == box2.Width &&
               box1.Height == box2.Height &&
               box1.Depth == box2.Depth;

        public override bool Equals(object obj)
        {
            return ReferenceEquals(this, obj) || (Box)obj == this;
        }

        public static bool operator !=(Box box1, Box box2)
            => !(box1 == box2);

        public static bool operator <(Box box1, Box box2)
            => box1.Area < box2.Area;

        public static bool operator >(Box box1, Box box2)
            => box2.Area < box1.Area;
    }
}
