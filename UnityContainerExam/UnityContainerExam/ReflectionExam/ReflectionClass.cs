using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnityContainerExam.ReflectionExam
{
    public class ReflectionClass
    {
        public String _Property1 { get; set; }
        public String _Property2 { get; set; }


        public ReflectionClass()
        {
        }

        public ReflectionClass(String Property1, String Property2)
        {
            _Property1 = Property1;
            _Property2 = Property2;
        }
        public void SetValues(String Prop1, String Prop2)
        {
            _Property1 = Prop1;
            _Property2 = Prop2;
        }
        public void ClearValues()
        {
            _Property1 = null;
            _Property2 = null;
        }
    }
}
