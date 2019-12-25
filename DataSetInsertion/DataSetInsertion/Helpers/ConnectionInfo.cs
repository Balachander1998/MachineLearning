using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSetInsertion.Helpers
{
    public class ConnectionInfo
    {
        public string ServerName
        {
            get;
            set;
        }

        public string UserName
        {
            get;
            set;
        }

        public string Password
        {
            get;
            set;
        }

        public string Database
        {
            get;
            set;
        }

        public string Port
        {
            get;
            set;
        }

        public bool IntegratedSecurity
        {
            get;
            set;
        }

        public string TableName
        {
            get;
            set;
        }

        public string FileName
        {
            get;
            set;
        }
    }
}
