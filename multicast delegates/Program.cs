using System;

namespace multicast_delegates
{
delegate void SampleDelegate();
internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            SampleDelegate dele,del1, del2, del3,del4;
            dele = new SampleDelegate(sample1);
            del1 = new SampleDelegate(sample1);
             del2 = new SampleDelegate(sample2);
            del3 = new SampleDelegate(sample3);
            del4 = del1 + del2 + del3-del3;
            del4();
            dele += sample2;
            dele();
           
        }
        public static void sample1()
        {
            Console.WriteLine("sampkle method 1 is invoked");
        }
        public static void sample2()
        {
            Console.WriteLine("sampkle method 2 is invoked");
        }
        public static void sample3()
        {
            Console.WriteLine("sampkle method 3 is invoked");
        }
    }
}
