using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSetInsertion.Helpers
{
    public class DataSetGenerationBase
    {
        public List<TemplateInfo> TemplateInfo
        {
            get;
            set;
        }

        public string WorkflowName
        {
            get;
            set;
        }

        public ConnectionInfo ConnectionInfo
        {
            get;
            set;
        }

        public ExportTypes ExportType
        {
            get;
            set;
        }

        public List<ColumnInfo> ColumnInfos
        {
            get;
            set;
        }

        public int MaxRows
        {
            get;
            set;
        }
    }
}
