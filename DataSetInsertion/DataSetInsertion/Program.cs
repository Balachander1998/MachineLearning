using DataSetInsertion.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataSetInsertion.Base;
using DataSetInsertion.Interface;
using DataSetInsertion.DataTypes;

namespace DataSetInsertion
{
    public class Program
    {
        static IDatabaseBase DatabaseBase;

        static IDataTypes DataTypes;
        public static DataSetGenerationBase DataSetGenerationObject;
        static void Main(string[] args)
        {
            ConnectionInfo connectionInfo = new ConnectionInfo
            {
                ServerName = "SYNCLAPN13974",
                IntegratedSecurity = false,
                UserName = "sa",
                Password = "sync1234",
                Database = "kavinTest"
            };

            ColumnInfo columnInfo = new ColumnInfo
            {
                ColumnName = "First_name",
                TemplateColumn = "Region",
                SimplifiedType = SimplifiedTypes.String
            };

            ColumnInfo columnInfo_2 = new ColumnInfo
            {
                ColumnName = "last_name",
                TemplateColumn = "Region",
                SimplifiedType = SimplifiedTypes.String
            };

            List<ColumnInfo> columnInfos = new List<ColumnInfo>();
            columnInfos.Add(columnInfo);
            columnInfos.Add(columnInfo_2);


            DataSetGenerationObject = new DataSetGenerationBase
            {
                ConnectionInfo = connectionInfo,
                WorkflowName = "Untitiled_1",
                ExportType = ExportTypes.SQLServer,
                MaxRows = 4
            };

            CreateTargetServer();
            GetEquivalentType(columnInfos);
            DataSetGenerationObject.ColumnInfos = columnInfos;
            CreateTable();
            InsertTable();

        }

        private static void CreateTargetServer()
        {
            switch(DataSetGenerationObject.ExportType)
            {
                case ExportTypes.SQLServer:
                    DatabaseBase = new SQLserverbase();
                    DataTypes = new SqlServerDataTypes();
                    break;
                default:
                    DatabaseBase = new SQLserverbase();
                    DataTypes = new SqlServerDataTypes();
                    break;
            }
        }

        private void GenerateDataSet()
        {
            
        }

        private static void InsertTable()
        {
            DatabaseBase.InsertValuesIntoTable(DataSetGenerationObject.WorkflowName, DataSetGenerationObject.MaxRows, DataSetGenerationObject.ColumnInfos);
        }

        private static void CreateTable()
        {
            DatabaseBase.GetConnectionString(DataSetGenerationObject.ConnectionInfo);
            Result result = new Result();
            result = DatabaseBase.DoDropTable(DataSetGenerationObject.WorkflowName);
            if (result.Status)
            {
                result = DatabaseBase.CreateTable(DataSetGenerationObject.ColumnInfos, DataSetGenerationObject.WorkflowName);
            }
        }

        private static void GetEquivalentType(List<ColumnInfo> columnInfos)
        {
            if (columnInfos.Count > 0)
            {
                foreach (ColumnInfo columnInfo in columnInfos)
                {
                    columnInfo.DataType = DataTypes.GetEquivalentDataType(columnInfo.SimplifiedType);
                }
            }
            
        }

    }
}
