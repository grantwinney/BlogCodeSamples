using System.Numerics;

namespace GenericMathSupport.Example5
{
    public class Box : IAdditionOperators<Box, Box, Box>,
                       IComparisonOperators<Box, Box, bool>
    {
        public int Width { get; private set; }
        public int Height { get; private set; }
        public int Depth { get; private set; }
        private int Area { get => Width * Height * Depth; }

        public Box() { }

        public Box(int width, int height, int depth)
        {
            Width = width;
            Height = height;
            Depth = depth;
        }

        public static Box operator +(Box box1, Box box2)
        {
            var widestWidth = Math.Max(box1.Width, box2.Width);
            var deepestDepth = Math.Max(box1.Depth, box2.Depth);
            var combinedHeight = box1.Height + box2.Height;

            return new Box(widestWidth, combinedHeight, deepestDepth);
        }

        public static bool operator ==(Box? left, Box? right)
            => left?.Area == right?.Area;

        public static bool operator !=(Box? left, Box? right)
            => !(left == right);

        public static bool operator <(Box left, Box right)
            => left.Area < right.Area;

        public static bool operator >(Box left, Box right)
            => left.Area > right.Area;

        public static bool operator <=(Box left, Box right)
            => left.Area <= right.Area;

        public static bool operator >=(Box left, Box right)
            => left.Area >= right.Area;
    }

    public class Folder : IAdditionOperators<Folder, Folder, Folder>,
                          IComparisonOperators<Folder, Folder, bool>
    {
        public Folder() { }

        public Folder(List<string> filesA, List<string> filesB)
        {
            Files.AddRange(filesA);
            Files.AddRange(filesB);
        }

        public List<string> Files { get; set; } = new List<string>();

        public static Folder operator +(Folder folder1, Folder folder2)
            => new(folder1.Files, folder2.Files);

        public static bool operator ==(Folder? left, Folder? right)
            => left?.Files.Count == right?.Files.Count;

        public static bool operator !=(Folder? left, Folder? right)
            => !(left == right);

        public static bool operator <(Folder left, Folder right)
            => left.Files.Count < right.Files.Count;

        public static bool operator >(Folder left, Folder right)
            => right.Files.Count < left.Files.Count;

        public static bool operator <=(Folder left, Folder right)
            => left.Files.Count <= right.Files.Count;

        public static bool operator >=(Folder left, Folder right)
            => left.Files.Count >= right.Files.Count;
    }

    public class Fraction : IAdditionOperators<Fraction, Fraction, Fraction>,
                            IComparisonOperators<Fraction, Fraction, bool>
    {
        public Fraction() { }

        public Fraction(int numerator, int denominator)
        {
            Numerator = numerator;
            Denominator = denominator;
        }

        public int Numerator { get; private set; }
        public int Denominator { get; private set; }
        public decimal Value
        {
            get
            {
                if (Denominator == 0)
                    throw new DivideByZeroException();
                return Numerator / (decimal)Denominator;
            }
        }

        public static Fraction operator +(Fraction f1, Fraction f2)
            => new(f1.Numerator * f2.Denominator + f2.Numerator * f1.Denominator, f1.Denominator * f2.Denominator);

        public static bool operator ==(Fraction? left, Fraction? right)
            => left?.Value == right?.Value;

        public static bool operator !=(Fraction? left, Fraction? right)
            => !(left == right);

        public static bool operator <(Fraction left, Fraction right)
            => left.Value < right.Value;

        public static bool operator >(Fraction left, Fraction right)
            => left.Value > right.Value;

        public static bool operator <=(Fraction left, Fraction right)
            => left.Value <= right.Value;

        public static bool operator >=(Fraction left, Fraction right)
            => left.Value >= right.Value;
    }

    public static class Utilities
    {
        public static T Sum<T>(this IEnumerable<T> items) where T : IAdditionOperators<T, T, T>, new()
        {
            if (!items.Any())
                return new();

            T sum = items.First();

            foreach (var item in items.Skip(1))
                sum += item;

            return sum;
        }

        public static T? Least<T>(this IEnumerable<T> items) where T : IComparisonOperators<T, T, bool>, new()
        {
            T? min = default;

            foreach (T item in items)
                if (min == null || item < min)
                    min = item;

            return min;
        }
    }
}
