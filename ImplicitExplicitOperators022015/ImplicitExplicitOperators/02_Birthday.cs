using System;

namespace ImplicitExplicitOperators
{
    public class Birthday
    {
        private readonly DateTime _birthday;

        public Birthday() { }

        private Birthday(DateTime birthday)
        {
            _birthday = birthday;
        }

        public static implicit operator Birthday(DateTime birthday)
        {
            return new Birthday(birthday);
        }

        public static implicit operator DateTime(Birthday birthday)
        {
            return birthday._birthday;
        }

        public static explicit operator int(Birthday birthday)
        {
            TimeSpan exactAge = DateTime.Now - birthday._birthday;

            return (int)(exactAge.TotalDays / 365);
        }
    }
}
