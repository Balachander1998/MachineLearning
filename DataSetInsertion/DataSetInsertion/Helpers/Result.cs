using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSetInsertion.Helpers
{
    public class Result
    {
        public bool Status
        {
            get;
            set;
        }

        public string ErrorMsg
        {
            get;
            set;
        }

        public object Data
        {
            get;
            set;
        }
    }
}
