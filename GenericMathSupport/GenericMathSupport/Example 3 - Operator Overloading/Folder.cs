namespace GenericMathSupport
{
    public class Folder
    {
        public Folder() { }

        public Folder(List<string> filesA, List<string> filesB)
        {
            Files.AddRange(filesA);
            Files.AddRange(filesB);
        }

        public List<string> Files { get; set; } = new List<string>();

        public static Folder operator +(Folder fdr1, Folder fdr2) =>
            new(fdr1.Files, fdr2.Files);
    }
}