using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UnityContainerExam.ThreadingExam
{
    public class Variability
    {
        bool done;
        private object locker;
        public Variability()
        {
            done = false;
            locker = new object();
        }
        public  void FirstThread()
        {
            Console.WriteLine("Y");
        }

        public  void SecondThread()
        {
            lock(locker){
                if (!done)
                {
                    done = true;
                    Console.WriteLine("done");
                }
            }           
        }

        public void ThirdThread(object name)
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(Thread.CurrentThread.Name + "yusoof");
                Console.WriteLine(name.ToString() + i);
            }                
        }
    }
}
