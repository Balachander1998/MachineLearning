using DataSetInsertion.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSetInsertion.Interface
{
    public  interface IDatabaseBase
    {
        Result GenerateCreateTableQuery(List<ColumnInfo> columnInfos, string tableName);

         Result ExecuteQuery(string query);

         bool IsValidConnection();

        Result DoDropTable(string tableName);

        Result CreateTable(List<ColumnInfo> columnInfos,string tableName);

        string GetConnectionString(ConnectionInfo connectionInfo);

        Result InsertValuesIntoTable(string tableName, int MaxRows, List<ColumnInfo> columnInfos);
    }
}
