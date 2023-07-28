namespace SingletonVsTransientDI
{
    public interface IIDSingleton : IID { }
    public interface IIDScoped : IID { }
    public interface IIDTransient : IID { }

    public interface IID
    {
        Guid Value { get; }
    }

    public class ID : IIDSingleton, IIDScoped, IIDTransient
    {
        public Guid Value { get; private set; } = Guid.NewGuid();
    }
}
