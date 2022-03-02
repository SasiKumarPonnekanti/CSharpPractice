using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestQuestions.Questions;

namespace TestQuestions.Questions
{
    //Can we have method overloading across base and deried classe?
    public class Mybase2
    {
        public int Add(int x,int y)
        {
            return x + y;
        }
    }
    public class Derive:Mybase2
    {
        public int Add(int x,int y,int z)
        {
            return x+y+z;
        }

    }
    // Answer Yes

    
}
