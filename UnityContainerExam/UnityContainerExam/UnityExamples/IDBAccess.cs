using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnityContainerExam.UnityExamples
{
    public interface IDBAccess
    {
        string connection { get; set; }
    }
}
