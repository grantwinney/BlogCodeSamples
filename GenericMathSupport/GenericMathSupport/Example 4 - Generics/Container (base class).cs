namespace GenericMathSupport.Example4
{
    public class Container<T>
    {
        public T Identifier { get; set; }

        public string GetIdentifier()
            => $"The identifier is: {Identifier}";
    }

    public class Box : Container<int>
    {
        public Box(int identifier)
        {
            Identifier = identifier;
        }
    }

    public class Crate : Container<string>
    {
        public Crate(string identifier)
        {
            Identifier = identifier;
        }
    }

    public class Folder : Container<Guid>
    {
        public Folder(Guid identifier)
        {
            Identifier = identifier;
        }
    }
}
