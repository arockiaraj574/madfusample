using BNPL_ENV.Model;
using Data.Configuration;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DataProcessor.Model.Processor
{
    public class ProcessModel:IProcessModel
    {
        private IHostingEnvironment Environment;
        private ConfigSettings DataConfiguration;

        public ProcessModel()
        {
            DataConfiguration = new ConfigSettings();
        }

        public void SetConfigSettings(ConfigSettings _DataConfiguration)
        {
            DataConfiguration = _DataConfiguration;
        }

        public DatasetModel Now(DatasetModel _dataSetModel)
        {

            return _dataSetModel;
        }
    }
}
