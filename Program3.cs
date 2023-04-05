using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpPrac;

namespace CSharpPrac
{
    class Program3
    {

        Program p1 = new Program();
        public void getProgram()
        {
            Console.WriteLine("");
            Console.WriteLine("-----Calling Program Method(getdata) from Program 3-----");
            p1.getData();
            Console.WriteLine("-----This is in Program 3 : getProgram method ending-----");
            Console.WriteLine("");
        }

    }
}
