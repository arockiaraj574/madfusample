using BNPL_ENV.Model;
using Data.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DataProcessor.Model.Processor
{
    public interface IProcessModel
    {
        void SetConfigSettings(ConfigSettings _DataConfiguration);
        DatasetModel Now(DatasetModel _dataSetModel);

    }
}
