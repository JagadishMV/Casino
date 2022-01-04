using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino
{
    class testClass
    {
    }


    class A
    {
        public A()
        {
            Console.WriteLine("constructor of A called..");
        }
        public void Print()
        {
            Console.WriteLine("A");
        }
    }

    class B : A
    {
        public B()
        {
            super();
            Console.WriteLine("constructor of B called..");
        }
        public void Print()
        {
            Console.WriteLine("B");
        }
    }

    class C
    {
        static void Main(string[] args)
        {
            A a = new B();
            a.Print();
            Console.Read();
        }
    }
}
