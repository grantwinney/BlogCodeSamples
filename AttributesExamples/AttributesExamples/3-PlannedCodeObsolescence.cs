using System;

namespace AttributesExamples
{
    public class PlannedCodeObsolescence
    {
        string firstName;
        string lastName;
        int age;

        [Obsolete("SetFirstName and SetLastName are more reliable and replace this method.")]
        public void SetName(string name)
        {
            var names = name.Split();
            firstName = names[0];
            lastName = names[1];
        }

        public void SetFirstName(string first)
        {
            firstName = first;
        }

        public void SetLastName(string last)
        {
            lastName = last;
        }

        [Obsolete("Function renamed to SetAge in v2.4 for consistency", true)]
        public void AgeSet(int age)
        {
            SetAge(age);
        }

        public void SetAge(int age)
        {
            this.age = age;
        }
    }
}
