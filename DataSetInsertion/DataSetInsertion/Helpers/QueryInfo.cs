using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSetInsertion.Helpers
{
    public static class QueryInfo
    {
        public static string SQLConnectionString = "Data Source={0}; Integrated Security={1};Initial Catalog = {2};User ID = {3};Password = {4};";

        public static string SQLCreateTableQuery = "CREATE TABLE [{0}] ({1})";

        public static string SQLDropTableQuery = "IF OBJECT_ID('{0}', 'U') IS NOT NULL DROP TABLE {1};";

        public static string SQLInsertQuery = "INSERT INTO [{0}] VALUES {1}";

        public static string MySQLCreateTableQuery = "CREATE TABLE `{0}` ({1})";

        public static string MySQLDropTableQuery = "DROP TABLE IF EXISTS {0};";

        public static string MySQLInsertQuery = "INSERT INTO `{0}` VALUES ({1})";
    }
}
