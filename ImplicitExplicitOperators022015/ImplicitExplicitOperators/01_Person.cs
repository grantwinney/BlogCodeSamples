namespace ImplicitExplicitOperators
{
    public class Person
    {
        private string _name;

        public Person(string name)
        {
            _name = name;
        }

        public static implicit operator Person(string name)
        {
            return new Person(name);
        }

        public static implicit operator string(Person person)
        {
            return person._name;
        }
    }
}
