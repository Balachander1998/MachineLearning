using DataSetInsertion.DataTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSetInsertion.Interface
{
    public interface IDataTypes
    {
        string GetEquivalentDataType(SimplifiedTypes simplifiedTypes);
    }
}
