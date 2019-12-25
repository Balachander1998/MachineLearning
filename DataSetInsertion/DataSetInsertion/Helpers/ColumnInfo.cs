using DataSetInsertion.DataTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSetInsertion.Helpers
{
    public class ColumnInfo
    {
        public string ColumnName
        {
            get;
            set;
        }

        public string DataType
        {
            get;
            set;
        }

        public SimplifiedTypes SimplifiedType
        {
            get;
            set;
        }
        public string TemplateColumn
        {
            get;
            set;
        }
    }
}
