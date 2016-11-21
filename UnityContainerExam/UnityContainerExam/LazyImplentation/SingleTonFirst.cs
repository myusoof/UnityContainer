using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnityContainerExam.LazyImplentation
{
    public sealed class SingleTonFirst
    {
        private static SingleTonFirst instance = null;

        private SingleTonFirst()
        {

        }

        public void PrintSingleton()
        {
            Console.WriteLine("First singleton pattern");            
        }

        public static SingleTonFirst Instance {
            get{
                if (instance == null)
                {
                    instance = new SingleTonFirst();
                }
                return instance;
            }
        }
        
    }
}
