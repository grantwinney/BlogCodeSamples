using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace UsingAnnotationsToAssistReSharper
{
    public class MainClass
    {
        /* RESHARPER AND OPTIMISTIC ANALYSIS */

        // ReSharper’s analysis detects that “name” will always be null, and underlines it to warn that
        //  accessing the “Length” property will possibly throw an exception. In this case, we know it will.
        private int ReSharperAnalyzesStringAsNull_ALWAYS()
        {
            string name = null;

            if (false)
                name = "";

            return name.Length;
        }

        // ReSharper’s analysis detects that name will never be null, so no underline.
        //  (It also grays out the first initialization, as it’s never used).
        private int ReSharperAnalyzesStringAsNull_NEVER()
        {
            string name = null;

            if (true)
                name = "";

            return name.Length;
        }

        // Now I’ll remove part of the code to a separate method.
        //  Obviously, a NullReferenceException will still be thrown, but ReSharper no longer warns us.
        private int ShowName()
        {
            return GetName().Length;
        }

        private string GetName()
        {
            return null;
        }

        /* GET A CLUE! */

        // ReSharper can’t determine whether the method could possibly return null, but we can give it a nudge nudge wink wink,
        //  using some special attributes from JetBrains (also referred to as “annotations” or “contracts”).
        private int ShowName2()
        {
            return GetNameCouldBeNull().Length;
        }

        [CanBeNull]
        private string GetNameCouldBeNull()
        {
            return null;
        }

        // Here’s another example, where the annotation has been applied to a parameter.
        //  Again, ReSharper doesn’t know whether or not “myString” could possibly be null, so it optimistically assumes it won’t be.
        //  But we can annotate the parameter to hint to ReSharper that “myString” may very well be null. 
        private int GetStringLength([CanBeNull] string myString)
        {
            return myString.Length;
        }

        // Here’s the NotNull attribute in action. Accessing the value of a nullable int,
        //  without first checking whether or not it has a value, will throw an exception, and ReSharper is warning us.
        private void Calculate()
        {
            var product1 = MultiplyByTwo(10).Value;  // Expect 20 :p

            var product2 = MultiplyByTwoCantPossiblyReturnNull(10).Value;
        }

        private int? MultiplyByTwo(int number)
        {
            return number * 2;
        }

        // By marking the called method with the NotNull attribute, we are telling ReSharper that the method will never return a null,
        //  so the warning is unnecessary. (Silly example, as you’d change the return value in the signature instead, but it demonstrates the usage.)
        [NotNull]
        private int? MultiplyByTwoCantPossiblyReturnNull(int number)
        {
            return number * 2;
        }

        /* USING ANNOTATIONS */

        // NHibernate’s NullableDictionary class allows null keys, but ReSharper wants to warn us that the key CAN'T be null (untrue):
        public class NullableDictionary<TKey, TValue> : IDictionary<TKey, TValue>
            where TKey : class
        {
            private TValue _nullvalue;
            private bool _gotNullvalue;
            private readonly Dictionary<TKey, TValue> _dict;

            public bool TryGetValue(TKey key, out TValue value)
            {
                if (key == null)
                {
                    if (_gotNullvalue)
                    {
                        value = _nullvalue;
                        return true;
                    }
                    else
                    {
                        value = default(TValue);
                        return false;
                    }
                }
                else
                {
                    return _dict.TryGetValue(key, out value);
                }
            }

            #region Ignore
            public bool ContainsKey(TKey key)
            {
                throw new NotImplementedException();
            }

            public void Add(TKey key, TValue value)
            {
                throw new NotImplementedException();
            }

            public bool Remove(TKey key)
            {
                throw new NotImplementedException();
            }

            public TValue this[TKey key]
            {
                get { throw new NotImplementedException(); }
                set { throw new NotImplementedException(); }
            }

            public ICollection<TKey> Keys { get; private set; }
            public ICollection<TValue> Values { get; private set; }

            public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
            {
                throw new NotImplementedException();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }

            public void Add(KeyValuePair<TKey, TValue> item)
            {
                throw new NotImplementedException();
            }

            public void Clear()
            {
                throw new NotImplementedException();
            }

            public bool Contains(KeyValuePair<TKey, TValue> item)
            {
                throw new NotImplementedException();
            }

            public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
            {
                throw new NotImplementedException();
            }

            public bool Remove(KeyValuePair<TKey, TValue> item)
            {
                throw new NotImplementedException();
            }

            public int Count { get; private set; }
            public bool IsReadOnly { get; private set; }
            #endregion Ignore
        }

        // Adding a [CanBeNull] attribute to the key parameter informs ReSharper that the key COULD be null:
        public class NullableDictionary2<TKey, TValue> : IDictionary<TKey, TValue>
            where TKey : class
        {
            private TValue _nullvalue;
            private bool _gotNullvalue;
            private readonly Dictionary<TKey, TValue> _dict;

            public bool TryGetValue([CanBeNull] TKey key, out TValue value)
            {
                if (key == null)
                {
                    if (_gotNullvalue)
                    {
                        value = _nullvalue;
                        return true;
                    }
                    else
                    {
                        value = default(TValue);
                        return false;
                    }
                }
                else
                {
                    return _dict.TryGetValue(key, out value);
                }
            }

            #region Ignore
            public bool ContainsKey(TKey key)
            {
                throw new NotImplementedException();
            }

            public void Add(TKey key, TValue value)
            {
                throw new NotImplementedException();
            }

            public bool Remove(TKey key)
            {
                throw new NotImplementedException();
            }

            public TValue this[TKey key]
            {
                get { throw new NotImplementedException(); }
                set { throw new NotImplementedException(); }
            }

            public ICollection<TKey> Keys { get; private set; }
            public ICollection<TValue> Values { get; private set; }

            public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
            {
                throw new NotImplementedException();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }

            public void Add(KeyValuePair<TKey, TValue> item)
            {
                throw new NotImplementedException();
            }

            public void Clear()
            {
                throw new NotImplementedException();
            }

            public bool Contains(KeyValuePair<TKey, TValue> item)
            {
                throw new NotImplementedException();
            }

            public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
            {
                throw new NotImplementedException();
            }

            public bool Remove(KeyValuePair<TKey, TValue> item)
            {
                throw new NotImplementedException();
            }

            public int Count { get; private set; }
            public bool IsReadOnly { get; private set; }
            #endregion Ignore
        }
    }
}
