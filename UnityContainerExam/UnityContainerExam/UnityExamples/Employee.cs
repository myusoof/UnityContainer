using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnityContainerExam.UnityExamples
{
    public class Employee
    {
        public IDBAccess _IDBAccess;

        public Employee(IDBAccess IDBAccess)
        {
            _IDBAccess = IDBAccess;
        }
    }
}
