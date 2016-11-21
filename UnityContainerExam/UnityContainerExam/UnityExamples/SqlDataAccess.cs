using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnityContainerExam.UnityExamples
{
    public class SqlDataAccess : IDBAccess
    {
        public string _connection;
        public string connection
        {
            get { return "test connection"; }
            set { _connection = value; }
        }
    }
}
