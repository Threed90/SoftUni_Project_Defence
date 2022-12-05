using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tellers.Mapper.Interfaces;

namespace Tellers.Mapper
{
    /// <summary>
    /// Wrapper class for Automapper to allow data binding between dataModels and view model.
    /// The meaning of the class is to avoid service layer to understand of view models and also application layer to understand of datamodels.
    /// Also helps to avoid the direct using of data model into application layer.
    /// </summary>
    public class MapWrapper : IMapWrapper
        
    {
        private readonly IMapper mapper;
        private readonly IConfigurationProvider config;

        /// <summary>
        /// The constructor have to create needed configuration, based on the given collection of profiles.
        /// </summary>
        /// <param name="profiles"></param>
        public MapWrapper(IProfileCollection profiles)
        {
            this.config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfiles(profiles.GetProfiles());
            });

            this.mapper = config.CreateMapper();
        }

        /// <summary>
        /// Returns view model from given data model.
        /// </summary>
        /// <typeparam name="TDataModel">Data model generic abstraction</typeparam>
        /// <typeparam name="TViewModel">View model generic abstraction</typeparam>
        /// <param name="dataModel"></param>
        /// <returns></returns>
        public TViewModel GetModel<TDataModel, TViewModel>(TDataModel dataModel)
            where TDataModel : class
            where TViewModel : class
        {
            return mapper.Map<TDataModel, TViewModel>(dataModel);
        }
    }
}
