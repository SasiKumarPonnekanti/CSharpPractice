using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions.Question_5
{
    internal class Question_5
    {
        def1 c1 = new def1();
        def2 c2 = new def2();
        def1 c3 = new def2();
        
        
    }
    public class def1
    {
        public void print()
        {
            Console.WriteLine("base print");
        }

    }
    public class def2 : def1
    {
        public void print()
        {
            Console.WriteLine("Derived print");
        }

    }
}
