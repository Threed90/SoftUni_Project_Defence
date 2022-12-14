using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Tellers.Mapper.Exceptions;
using Tellers.Mapper.Interfaces;
using Tellers.Mapper.Profiles;

namespace Tellers.Mapper
{
    /// <summary>
    /// Wrapper class for Automapper to allow data binding between dataModels and view model.
    /// The meaning of the class is to avoid service layer to understand of view models and also application layer to understand of datamodels.
    /// Also helps to avoid the direct using of data model into application layer.
    /// </summary>
    public class MapWrapper : IMapWrapper

    {
        private IMapper mapper = null!;
        private readonly List<(Type destination, Type source)> mapTypes;
        private readonly List<Profile> profiles;
        private IConfigurationProvider config = null!;
        private bool isConfigurationSettled;
        private List<string> profileNames;

        /// <summary>
        /// The constructor have to create needed configuration, based on the given collection of profiles.
        /// </summary>
        /// <param name="profiles"></param>
        public MapWrapper()
        {
            this.mapTypes = new();
            this.isConfigurationSettled = false;
            this.profiles = new List<Profile>();
            this.profileNames = new List<string>();
        }

        public IMapWrapper ApplyAllMaps()
        {
            this.config = new MapperConfiguration(cfg =>
            {
                foreach (var type in mapTypes)
                {
                    cfg.CreateMap(type.source, type.destination);
                }

                foreach (var profile in profiles)
                {
                    cfg.AddProfile(profiles.FirstOrDefault(p => profileNames.Contains(p.GetType().Name)));
                }
                    

            });

            if (mapTypes.Count == 0 && profiles.Count == 0)
            {
                throw new MissingMapCreationsException();
            }

            this.mapper = config.CreateMapper();

            this.isConfigurationSettled = true;
            return this;
        }

        /// <summary>
        /// Create a mapping configuration between two objects. It is using Automapper default behaviour or simple behaviour ForMember-MapFrom.
        /// </summary>
        /// <typeparam name="TDestination"></typeparam>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="destinationProperty"></param>
        /// <param name="sourceProperty"></param>
        /// <returns></returns>
        public IMapWrapper CreateMap<TDestination, TSource>()
            where TDestination : class
            where TSource : class
        {

            this.mapTypes.Add((typeof(TDestination), typeof(TSource)));

            return this;
        }

        /// <summary>
        /// Returns view model from given data model.
        /// </summary>
        /// <typeparam name="TDestination">Data model generic abstraction</typeparam>
        /// <typeparam name="TSource">View model generic abstraction</typeparam>
        /// <param name="destination"></param>
        /// <returns></returns>
        public TDestination GetModel<TDestination, TSource>(TSource source)
            where TDestination : class
            where TSource : class
        {
            this.CheckAgainsNoMaps();

            return mapper.Map<TSource, TDestination>(source);
        }

        public IMapWrapper AddProfile<TSource>()
        {
            var profileName = typeof(TSource).Name + "Profile";
            profileNames.Add(profileName);
            var @namespace = "Tellers.Mapper.Profiles.";
            var profile = (Profile)Activator.CreateInstance(Type.GetType(@namespace + profileName));
            profiles.Add(profile);

            return this;
        }


        public IEnumerable<TDestination> GetModels<TDestination, TSource>(IEnumerable<TSource> destination)
            where TDestination : class
            where TSource : class
        {
            this.CheckAgainsNoMaps();

            return destination
                .Select(m => this.mapper.Map<TSource, TDestination>(m));
        }

        public IQueryable<TDestination> GetModelsAsIQueryable<TDestination, TSource>(IQueryable<TSource> destination)
            where TDestination : class
            where TSource : class
        {
            this.CheckAgainsNoMaps();

            return destination
                .ProjectTo<TDestination>(this.GetConfig());

        }



        /// <summary>
        /// Inner method for passing the configuration to other methods.
        /// </summary>
        /// <returns></returns>
        private IConfigurationProvider GetConfig()
        {
            return config;
        }

        /// <summary>
        /// Checking if there are no applied mappings.
        /// </summary>
        /// <exception cref="NoAppliedMappingsException"></exception>
        private void CheckAgainsNoMaps()
        {
            if (this.isConfigurationSettled == false)
            {
                throw new NoAppliedMappingsException();
            }
        }

        
    }
}
