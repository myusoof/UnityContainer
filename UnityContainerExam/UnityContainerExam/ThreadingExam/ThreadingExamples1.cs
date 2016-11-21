using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace UnityContainerExam.ThreadingExam
{
    [Binding]
    public class ThreadingExamples1
    {
        [Given(@"I have the start the first thread")]
        public void GivenIHaveTheStartTheFirstThread()
        {
            Variability varia = new Variability();
            varia.FirstThread();
            Thread thread1 = new Thread(varia.FirstThread);
            thread1.Start();
            thread1.Abort();

        }
        [Given(@"I have the start the second thread")]
        public void GivenIHaveTheStartTheSecondThread()
        {
            Variability varia = new Variability();
            varia.SecondThread();
            Thread thread2 = new Thread(varia.SecondThread);
            thread2.Start();
            thread2.Abort();
        }
        [Given(@"I have the start the third thread")]
        public void GivenIHaveTheStartTheThirdThread()
        {
            Variability varia = new Variability();
            Thread thread2 = new Thread(new ParameterizedThreadStart(varia.ThirdThread));
            thread2.Start("second");
            thread2.Join();
            varia.ThirdThread("main");
            Thread.Sleep(10000);
            thread2.Abort();
        }

        [Given(@"I use the thread with delegate")]
        public void GivenIUseTheThreadWithDelegate()
        {
            for (int i = 0; i < 10; i++)
            {
              new Thread(() => { Console.WriteLine(i); }).Start();
            }           
                
        }

        [Given(@"I name the thread")]
        public void GivenINameTheThread()
        {
            Thread.CurrentThread.Name = "main";
            Variability varia = new Variability();
            Thread thread2 = new Thread(new ParameterizedThreadStart(varia.ThirdThread));
            thread2.Name = "seconds";
            thread2.Start("second");            
            thread2.Join();
            varia.ThirdThread("main");           
            Thread.Sleep(10000);
            thread2.Abort();
        }

        [Given(@"I name the thread with TPL")]
        public void GivenINameTheThreadWithTPL()
        {            
            Variability varia = new Variability();
            Thread thread2 = new Thread(new ParameterizedThreadStart(varia.ThirdThread));
            Task.Factory.StartNew(varia.FirstThread);
        }
        [Given(@"I name the thread with TPL with generic")]
        public void GivenINameTheThreadWithTPLWithGeneric()
        {
            Task<string> task = Task.Factory.StartNew<string>
                (() => DownloadString("http://www.google.co.in"));
            // We can do other work here and it will execute in parallel:
            Console.WriteLine(task.Result);
            Go();
            // When we need the task's return value, we query its Result property:
            // If it's still executing, the current thread will now block (wait)
            // until the task finishes:
            
        }
        public string DownloadString(string uri)
        {
            using (var wc = new System.Net.WebClient())
                return wc.DownloadString(uri);
        } 
        public string Go(){
            var client = new System.Net.WebClient();
            string abs = client.DownloadString("https://www.google.co.in/");
            Console.WriteLine("Yusoof");
            return abs;
        }
    }
}
