using BNPL_ENV.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DataProcessor.Query
{
    public interface IQueryResolver
    {

        string Table { get; }
        DatasetModel GetQueryObject(DataTable dTable, DatasetModel dataSetModel);
    }
}
