using System;

namespace TimeClass
{
    class Program
    {
        static void Main(string[] args)
        {
            Time time1 = new Time(10, 61, 61);
            time1.Print();

            Time time2 = new Time(1, 1, 1);
            time2.Print();

            Time time3 = time1 + time2;
            time3.Print();
            time3 += time1;
            time3.Print();

            Console.WriteLine("time1 < time2 " + (time1 < time2));
            Console.WriteLine("time3 == time3 " + (time3 == time3));
        }
    }
}
