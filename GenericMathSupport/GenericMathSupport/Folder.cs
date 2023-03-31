using System.Drawing;
using System.Numerics;

namespace GenericMathSupport
{
    public class Folder : IAdditionOperators<Folder, Folder, Folder>
    {
        public Folder()
        {
        }

        public Folder(List<Document> filesA, List<Document> filesB)
        {
            Files.AddRange(filesA);
            Files.AddRange(filesB);
        }

        public List<Document> Files { get; set; } = new List<Document>();

        public static Folder operator +(Folder fdr1, Folder fdr2) =>
            new(fdr1.Files, fdr2.Files);

        public static int operator +(int fdr1, Folder fdr2) =>
            fdr1 + fdr2.Files.Count();

        static T Add<T>(T left, T right)
            where T : INumber<T>
                {
                    return left + right;
                }
    }

    public class Document
    {
        public string Name { get; set; } = "";
        public string FilePath { get; set; } = "";
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime Updated { get; set; } = DateTime.Now;
    }
}