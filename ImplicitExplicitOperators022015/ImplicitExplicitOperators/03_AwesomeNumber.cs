using System;

namespace ImplicitExplicitOperators
{
    public struct AwesomeNumber
    {
        private readonly int _number;

        private AwesomeNumber(int number)
        {
            _number = number;
        }

        public static implicit operator AwesomeNumber(int number)
        {
            return new AwesomeNumber(number);
        }

        public static implicit operator AwesomeNumber(short number)
        {
            return new AwesomeNumber(number);
        }

        public static explicit operator AwesomeNumber(double number)
        {
            return new AwesomeNumber((int)number);
        }

        public static explicit operator AwesomeNumber(decimal number)
        {
            return new AwesomeNumber((int)number);
        }

        public static implicit operator int(AwesomeNumber number)
        {
            return number._number;
        }
    }

    public struct NotSoAwesomeNumber
    {
        private readonly int _number;

        private NotSoAwesomeNumber(int number)
        {
            _number = number;
        }

        public static implicit operator NotSoAwesomeNumber(double number)
        {
            // Fail: Consumer thought they stored a double,
            //       but internally we dropped the fractional portion
            return new NotSoAwesomeNumber((int)number);
        }

        public static implicit operator double(NotSoAwesomeNumber number)
        {
            return number._number;
        }
    }
}
