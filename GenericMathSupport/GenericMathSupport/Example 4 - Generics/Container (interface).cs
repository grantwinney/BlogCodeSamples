namespace GenericMathSupport.Example4b
{
    public interface IContainer<T>
    {
        T Identifier { get; set; }
        string GetDescription();
    }

    public class Box : IContainer<int>
    {
        public int Identifier { get; set; }
        public string GetDescription() => $"The box id is {Identifier}.";
    }

    public class Crate : IContainer<Guid>
    {
        public Guid Identifier { get; set; }
        public string GetDescription() => $"The guid is: {Identifier}";
    }
}
