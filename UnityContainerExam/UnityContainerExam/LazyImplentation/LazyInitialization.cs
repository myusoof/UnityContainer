using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using UnityContainerExam.ThreadingExam;

namespace UnityContainerExam.LazyImplentation
{
    [Binding]
    public class LazyInitialization
    {

        [Given(@"I have first example for lazy object initialization")]
        public void GivenIHaveFirstExampleForLazyObjectInitialization()
        {            
            SingleTonFirst.Instance.PrintSingleton();
        }

        [Given(@"I have a thread to run")]
        public void GivenIHaveAThreadToRun()
        {
            Alpha Alpa = new Alpha();
            Thread thread = new Thread(new ParameterizedThreadStart(Alpa.Beta));
            thread.Start("child thread");
            Console.WriteLine(thread.IsAlive);
            Thread.Sleep(5000);
            thread.Abort();
        }

        [Given(@"I have a second thread to run")]
        public void GivenIHaveASecondThreadToRun()
        {
            Alpha alpha = new Alpha();
            new Thread(new ParameterizedThreadStart(alpha.Beta)).Start("Secondary thread");
            alpha.Beta("main thread");
        }

    }
}
