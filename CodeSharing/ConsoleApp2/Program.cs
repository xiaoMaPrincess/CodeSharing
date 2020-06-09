using System;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            //var a1 = new A { B = 1 };
            var a1 = new A { B = 1 };
            //Change(ref a1);
            //Console.WriteLine(a1.B);
            Console.WriteLine("Hello World!");
            Console.ReadKey();
        }
        static void Change(ref A a)
        {
            a.B = 2;
            a= new A { B = 3 };
        }
    }
    class A
    {
        public A()
        {

        }
        public A(int b,int c)
        {
            B = b;
            C = c;
        }
        public A(int b):this(b,4)
        {
            Console.WriteLine("aa");
        }
        public int B { get; set; }
        public int C { get; set; }
    }
}
