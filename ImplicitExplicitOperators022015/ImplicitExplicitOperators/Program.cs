using System;

namespace ImplicitExplicitOperators
{
    class Program
    {
        static void Main(string[] args)
        {
            // 01 Person
            Person person1 = new Person("Bob");             // call the ctor
            Person person2 = "Mary";                        // implicit conversion of String to Person
            string name = person2;
            

            // 02 Birthday           
            Birthday birthday1 = new Birthday();            // call the ctor

            Birthday birthday2 = new DateTime(1970, 6, 2);  // implicit conversion of DateTime to Birthday
            DateTime birthdate = birthday2;                 // implicit conversion of Birthday to DateTime

            int age = (int)birthday2;                       // explicit conversion of Birthday to Int32


            // 03 AwesomeNumber
            short s = 5;
            AwesomeNumber number1 = s;                      // implicit short
            AwesomeNumber number2 = 5;                      // implicit integer
                                                            
            AwesomeNumber number3 = (AwesomeNumber)2.0;     // explicit double
            AwesomeNumber number4 = (AwesomeNumber)5.0m;    // explicit decimal
            
            // 03b NotSoAwesomeNumber
            NotSoAwesomeNumber notSoAwesomeNumber = 5.3;
            double myOrigValue = notSoAwesomeNumber;        // Uh-oh, only get 5 back.


            // Two ways to initialize the Nullable<T> struct
            var date0a = (DateTime?)null;
            var date0b = new Nullable<DateTime>();

            
            //04 MyNullable<T>
            var date1 = new MyNullable<DateTime>();

            Console.WriteLine(String.Concat("Date 1 Value: ", date1.HasValue ? date1.Value.ToShortDateString() : "N/A"));
            // output> "Date 1 Value: N/A"

            MyNullable<DateTime> date2 = DateTime.Now;

            Console.WriteLine(String.Concat("Date 2 Value: ", date2.HasValue ? date2.Value.ToShortDateString() : "N/A"));
            // output> "Date 2 Value: 2/11/2015"

            DateTime getMyDate2 = (DateTime)date2;

            Console.ReadLine();
        }
    }
}
