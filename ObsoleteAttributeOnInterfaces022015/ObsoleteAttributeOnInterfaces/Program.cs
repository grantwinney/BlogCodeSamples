using System;

namespace ObsoleteAttributeOnInterfaces
{
    public static class Program
    {
        public static void Main()
        {
            ISampleClass sc1 = new SampleClass();
            sc1.SomeOldMethod();

            ISampleClass sc2 = new SampleClass2();
            sc2.SomeOldMethod();

            ISampleClass sc3 = new SampleClass3();
            sc3.SomeOldMethod();



            SampleClass sc = new SampleClass();
            sc.SomeOldMethod();

        }
    }

    public interface ISampleClass
    {
        void SomeOldMethod();
    }

    public class SampleClass : ISampleClass
    {
        [Obsolete("This is the old way. No one uses it anymore. Shame on you!!", true)]
        public void SomeOldMethod()
        {
            // This is old. I should probably remove and refactor, but I'm too scared.
        }
    }

    public class SampleClass2 : ISampleClass
    {
        public void SomeOldMethod()
        {
            // Old, but not obsolete.
        }
    }

    public class SampleClass3 : ISampleClass
    {
        public void SomeOldMethod()
        {
            // Why mess with perfection?
        }
    }
}
