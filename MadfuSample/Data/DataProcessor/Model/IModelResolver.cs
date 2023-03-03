using BNPL_ENV.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DataProcessor.Model
{
    public interface IModelResolver
    {
        string GetModelName { get; }
        Type GetModelType { get; }
        Type GetModelListType { get; }
        object GetModelObject<T>(DatasetModel dataSetModel);
    }
}
