using DataSetInsertion.DataTypes;
using DataSetInsertion.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSetInsertion.RandomDataPreparation
{
    public static class RandomDataPreparationBase
    {
        public static Dictionary<string, object> GetRandomData(List<ColumnInfo> columnInfos)
        {
            Dictionary<string, object> ColumnNamesWithValues= new Dictionary<string, object>();
            foreach(ColumnInfo columnInfo in columnInfos)
            {
                switch (columnInfo.SimplifiedType)
                {
                    case SimplifiedTypes.Number:
                        ColumnNamesWithValues.Add(columnInfo.ColumnName, 2);
                        break;
                    case SimplifiedTypes.String:
                        ColumnNamesWithValues.Add(columnInfo.ColumnName, "kavin");
                        break;
                    case SimplifiedTypes.Date:
                    case SimplifiedTypes.DateTime:
                        ColumnNamesWithValues.Add(columnInfo.ColumnName, DateTime.Now);
                        break;
                    default:
                        ColumnNamesWithValues.Add(columnInfo.ColumnName, "kavin_raj");
                        break;

                }
            }

            return ColumnNamesWithValues;
        }
    }
}
