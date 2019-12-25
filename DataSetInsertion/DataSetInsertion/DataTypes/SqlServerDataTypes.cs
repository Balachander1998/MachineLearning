using DataSetInsertion.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSetInsertion.DataTypes
{
    public class SqlServerDataTypes : IDataTypes
    {
        public string GetEquivalentDataType(SimplifiedTypes simplifiedTypes)
        {
            string dataType = "varchar(max)";
            switch(simplifiedTypes)
            {
                case SimplifiedTypes.Number:
                case SimplifiedTypes.Integer:
                    dataType = "int";
                    break;
                case SimplifiedTypes.String:
                    dataType = "varchar(max)";
                    break;
                case SimplifiedTypes.Date:
                case SimplifiedTypes.DateTime:
                case SimplifiedTypes.Time:
                    dataType = "datetime";
                    break;
                default:
                    return "varchar(max)";
                    
            }
            return dataType;
        }
    }
}
