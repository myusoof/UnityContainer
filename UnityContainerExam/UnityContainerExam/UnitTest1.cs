using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Practices.Unity;
using UnityContainerExam.UnityExamples;
using UnityContainerExam.ReflectionExam;
using System.Reflection;


namespace UnityContainerExam
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var container = new UnityContainer();
            container.RegisterType<IDBAccess, SqlDataAccess>();
            Employee employee = container.Resolve<Employee>();
            Console.WriteLine(employee._IDBAccess.connection);

            Rediff rediff = (Rediff)Activator.CreateInstance(typeof(Rediff));
            rediff._name = "Nasreen";
            rediff.PrintName();

            Type type = Type.GetType("UnityContainerExam.ReflectionExam.ReflectionClass");
            ReflectionClass reflectionClass = (ReflectionClass)Activator.CreateInstance(type, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance, null, new object[] { "yusoof", "mohmed" }, null);

            
            
            ReflectionClass reflectionClass1 = GenericReturn<ReflectionClass>();
            Console.WriteLine(reflectionClass1._Property1);
            Console.WriteLine(reflectionClass1._Property2);

            Func<int, string> func1 = (int a) => String.Format("string {0}", a);
            Console.WriteLine(func1(1));
            Console.WriteLine(func3());
            Console.WriteLine(func4);
        }

        Func<double> func3 = () => Math.PI;


        public T GenericReturn<T>()
        {
            return (T)Activator.CreateInstance(typeof(T), BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance, null, new object[] { "yusoof", "mohmed" }, null);
            
        } 
        public Double func4
        {
            get
            {
                return func3();
            }
        }
    }
}
