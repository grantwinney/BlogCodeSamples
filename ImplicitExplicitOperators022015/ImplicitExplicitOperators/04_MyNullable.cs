namespace ImplicitExplicitOperators
{
    //
    // My own Nullable<T>, reusing the parts of Nullable<T> I'm interested in
    //
    public struct MyNullable<T> where T : struct
    {
        private bool hasValue;
        internal T value;

        public MyNullable(T value)
        {
            this.value = value;
            this.hasValue = true;
        }

        public bool HasValue
        {
            get { return hasValue; }
        }

        public T Value
        {
            get { return value; }
        }

        public static implicit operator MyNullable<T>(T value)
        {
            return new MyNullable<T>(value);
        }

        public static explicit operator T(MyNullable<T> value)
        {
            return value.Value;
        }
    }
}
