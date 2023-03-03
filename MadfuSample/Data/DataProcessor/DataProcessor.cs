using BNPL_ENV.Model;
using Data.Configuration;
using Data.DataProcessor.Config;
using Data.DataProcessor.Model;
using Data.DataProcessor.Model.Processor;
using Data.DataProcessor.Query;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DataProcessor
{
    public class DataProcessor
    {
        private IProcessModel ProcessModel { get; }

        public static void Main()
        {

        }

        public DataProcessor()
        {
            ProcessModel = new ProcessModel();
        }

        public DataProcessor(String JsonSettings)
        {
            ConfigSettings settings = JsonConvert.DeserializeObject<ConfigSettings>(JsonSettings);
            ProcessModel = new ProcessModel();
            ProcessModel.SetConfigSettings(settings);
        }

        public DataProcessor(ConfigSettings settings)
        {
            ProcessModel = new ProcessModel();
            ProcessModel.SetConfigSettings(settings);
        }

        public object Start<T>(DataSet DatasetResp)
        {
            if (DatasetResp != null)
            {
                return ConvertDatasetToModel<T>(DatasetResp);
            }
            return null;
        }

        public object Start(DataSet DatasetResp)
        {
            if (DatasetResp != null)
            {
                return ConvertDatasetToModel(DatasetResp);
            }
            return null;
        }

        private Services GetServices()
        {
            return new Services();
        }

        private object ConvertDatasetToModel(DataSet DatasetResp)
        {
            Services _Services = GetServices();
            DatasetModel ModelList = new DatasetModel();

            if (ModelList == null) { ModelList = new DatasetModel(); }
            foreach (DataTable entity in DatasetResp.Tables)
            {
                if (entity.Rows.Count == 0) { continue; }
                String SourceName = entity.Rows[0]["Source"].ToString();
                IQueryResolver resolver = _Services.QueryService.Where(a => a.Table == SourceName).FirstOrDefault();
                ModelList = resolver.GetQueryObject(entity, ModelList);
            }
            ModelList = ProcessModel.Now(ModelList);
            return ModelList;
        }

        private object ConvertDatasetToModel<T>(DataSet DatasetResp)
        {
            Services _Services = GetServices();
            DatasetModel ModelList = new DatasetModel();

            if (ModelList == null) { ModelList = new DatasetModel(); }
            foreach (DataTable entity in DatasetResp.Tables)
            {
                if (entity.Rows.Count == 0) { continue; }
                try
                {
                    IQueryResolver resolver = _Services.QueryService.Where(a => a.Table == entity.Rows[0]["Source"].ToString()).FirstOrDefault();
                    if (resolver != null) ModelList = resolver.GetQueryObject(entity, ModelList);
                }

                catch (Exception exxx)
                {
                    Console.WriteLine(exxx.Message);
                }

            }

            ModelList = ProcessModel.Now(ModelList);

            IModelResolver _ModelResolver = _Services.ModelService.Where(a => a.GetModelType.Equals(typeof(T)) || a.GetModelListType.Equals(typeof(T))).FirstOrDefault();
            if (_ModelResolver != null)
            {
                return _ModelResolver.GetModelObject<T>(ModelList);
            }
            if (typeof(T).Equals(typeof(DatasetModel)))
            {
                return ModelList;
            }
            return (T)Activator.CreateInstance(typeof(T));
        }
    }
}

