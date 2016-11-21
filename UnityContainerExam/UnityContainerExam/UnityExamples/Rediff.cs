using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnityContainerExam.UnityExamples
{
    public class Rediff
    {
        public String _name;
        public Rediff()
        {
        }
        public Rediff(String name)
        {
            _name = name;
        }

        public void PrintName(){            
            Console.WriteLine(_name);
        }
    }
}
