using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UnityContainerExam.ThreadingExam
{
    public class Alpha
    {
        public static bool done = true;
        static readonly object locker = new object();
        public void Beta(object name)
        {        
            lock(locker) {
                 if(done)
            {
                Thread.Sleep(5000);
                done = false;
                Console.WriteLine(name);
            } 
            }
                          
        }
    }
}
