using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSetInsertion.Helpers
{
    public class TemplateInfo
    {
        public string TemplateName
        {
            get;
            set;
        }

        public List<ColumnInfo> ColumnInfos
        {
            get;
            set;
        }

        public ConnectionInfo ConnectionInfo
        {
            get;
            set;
        }
    }
}
