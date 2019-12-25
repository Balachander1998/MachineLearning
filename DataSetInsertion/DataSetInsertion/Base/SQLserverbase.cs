using DataSetInsertion.Helpers;
using DataSetInsertion.Interface;
using DataSetInsertion.RandomDataPreparation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSetInsertion.Base
{
    public class SQLserverbase : IDatabaseBase
    {
        public string ConnecionString = "";
        public Result GenerateCreateTableQuery(List<ColumnInfo> ColumnDetails, string tableName)
        {
            Result result = new Result();
            try
            {
                string columnNameWithDataType = "[{0}] {1},";
                string columnQuery = "";

                if (ColumnDetails != null && ColumnDetails.Count > 0)
                {
                    for (int i = 0; i < ColumnDetails.Count; i++)
                    {
                        columnQuery += string.Format(columnNameWithDataType, ColumnDetails[i].ColumnName, ColumnDetails[i].DataType);
                    }
                }

                columnQuery = columnQuery.Remove(columnQuery.Length -1,1);

                result.Status = true;
                result.Data = string.Format(QueryInfo.SQLCreateTableQuery, tableName, columnQuery);
            }

            catch(Exception ex)
            {
                result.Status = false;
                result.ErrorMsg = "Table not created- Generate table" + ex.Message;
            }

            return result;
        }

        public Result DoDropTable(string tableName)
        {
            Result result = new Result();
            string dropTableQuery = string.Format(QueryInfo.SQLDropTableQuery, tableName, tableName);
            result = ExecuteQuery(dropTableQuery);
            return result;
        }

        public string GetConnectionString(ConnectionInfo connectionInfo)
        {
            ConnecionString = string.Format(QueryInfo.SQLConnectionString, connectionInfo.ServerName, connectionInfo.IntegratedSecurity, connectionInfo.Database, connectionInfo.UserName, connectionInfo.Password);
            return ConnecionString;
        }

        public Result ExecuteQuery(string query)
        {
            Result result = new Result(); 
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnecionString))
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                result.Status = true;
                
            }
            catch(Exception ex)
            {
                result.Status = false;
                result.ErrorMsg = "Exexcute query issue SQL - " + ex.Message.ToString();
            }
            return result;
        }

        public bool IsValidConnection()
        {
            var c = new SqlConnection
            {
                ConnectionString = this.ConnecionString
            };

            c.Open();
            return c.State == ConnectionState.Open;
        }

        public Result InsertValuesIntoTable(string tableName,int MaxRows, List<ColumnInfo> columnInfos)
        {
            Result result = new Result();
            try
            {
                if (this.IsValidConnection())
                {
                    int MaximunValuesInsertInSingleExecution = (MaxRows % 500) > 0 ? (MaxRows / 500) + 1 : (MaxRows / 500);

                    for(int i=0;i<MaximunValuesInsertInSingleExecution;i++)
                    {
                        result = GenerateInsertTableQuery(columnInfos, 500, tableName);
                        if(result.Status == true)
                        {
                            result = ExecuteQuery(result.Data.ToString());
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                result.Status = false;
                result.ErrorMsg = "Insert values error occured" + ex.Message;
            }
            

            return result;
        }

        public Result CreateTable(List<ColumnInfo> columnInfos, string tableName)
        {
            Result result = new Result();
            try
            {
                result = this.GenerateCreateTableQuery(columnInfos, tableName);
                result = this.ExecuteQuery(result.Data.ToString());
                result.Status = true;
            }
            catch(Exception ex)
            {
                result.Status = false;
                result.ErrorMsg = "create table exception- " + ex.Message;
            }
            
            return result;
        }

        public Result GenerateInsertTableQuery(List<ColumnInfo> columnInfos, int MaxRows,string tableName)
        {
            Result result = new Result();
            string InsertQuery = "";
            int rowCount = 0;
            try
            {
                while (rowCount <= MaxRows)
                {
                    if (columnInfos.Count > 0)
                    {
                        Dictionary<string, object> keyValues = new Dictionary<string, object>();
                        keyValues = RandomDataPreparationBase.GetRandomData(columnInfos);
                        keyValues = UpdateKeyValuePairs(columnInfos, keyValues);
                        InsertQuery += "(" + PrepareInsertQuery(keyValues) + "),";
                    }
                    rowCount++;
                }
                InsertQuery = InsertQuery.Remove(InsertQuery.Length - 1, 1);
                InsertQuery = string.Format(QueryInfo.SQLInsertQuery, tableName, InsertQuery);

                result.Data = InsertQuery;
                result.Status = true;
            }
            catch(Exception ex)
            {
                result.Status = false;
                result.ErrorMsg = "Generate insert query fails - " + ex.Message;
            }
            return result;
        }

        private string PrepareInsertQuery(Dictionary<string, object> keyValues)
        {
            string values = "";
            foreach(KeyValuePair<string, object> column in keyValues)
            {
                values += column.Value + ",";
            }
            return values.Remove(values.Length - 1, 1);
        }

        public Dictionary<string, object> UpdateKeyValuePairs(List<ColumnInfo> columnInfos, Dictionary<string, object> keyValues)
        {
            foreach (ColumnInfo columnInfo in columnInfos)
            {
                if (keyValues.ContainsKey(columnInfo.ColumnName))
                {
                    switch (columnInfo.DataType)
                    {
                        case "int":
                            keyValues[columnInfo.ColumnName] = keyValues[columnInfo.ColumnName];
                            break;
                        case "varchar(max)":
                        case "datetime":
                            keyValues[columnInfo.ColumnName] = "'" + keyValues[columnInfo.ColumnName] + "'";
                            break;
                        default:
                            keyValues[columnInfo.ColumnName] = "'" + keyValues[columnInfo.ColumnName] + "'";
                            break;
                    }
                }
            }
            return keyValues;
        }
    }
}
