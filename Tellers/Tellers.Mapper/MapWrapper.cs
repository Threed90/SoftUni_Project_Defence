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
        private readonly List<(Type destination, Type source, string? destinationPropertyName, string? sourcePropertyName)> mapTypes;
        private IConfigurationProvider config = null!;
        private bool isConfigurationSettled;

        /// <summary>
        /// The constructor have to create needed configuration, based on the given collection of profiles.
        /// </summary>
        /// <param name="profiles"></param>
        public MapWrapper()
        {
            this.mapTypes = new();
            this.isConfigurationSettled = false;
        }

        public IMapWrapper ApplyAllMaps()
        {
            this.config = new MapperConfiguration(cfg =>
            {
                foreach (var type in mapTypes)
                {

                    if (type.destinationPropertyName != null && type.sourcePropertyName != null)
                    {
                        cfg.CreateMap(type.source, type.destination)
                            .ForMember(type.destinationPropertyName, opt => opt.MapFrom(type.sourcePropertyName));
                    }
                    else
                    {
                        cfg.CreateMap(type.source, type.destination);
                    }

                }
            });

            if(mapTypes.Count == 0)
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
        public IMapWrapper CreateMap<TDestination, TSource>(Expression<Func<TDestination>>? destinationProperty = null, Expression<Func<TSource>>? sourceProperty = null)
            where TDestination : class
            where TSource : class
        {
            string? destination = null;
            string? source = null;

            if (destinationProperty != null &&
                sourceProperty != null)
            {
                var memberExpressionDestination = (MemberExpression)destinationProperty.Body;
                var instanceExpressionDestination = memberExpressionDestination.Expression;
                var parameterDestination = Expression.Parameter(typeof(TDestination));
                destination = parameterDestination.Name;

                var memberExpressionSource = (MemberExpression)sourceProperty.Body;
                var instanceExpressionSource = memberExpressionSource.Expression;
                var parameterSource = Expression.Parameter(typeof(TDestination));
                source = parameterSource.Name;
            }

            this.mapTypes.Add((typeof(TDestination), typeof(TSource), destination, source));

            return this;
        }

        /// <summary>
        /// Returns view model from given data model.
        /// </summary>
        /// <typeparam name="TDestination">Data model generic abstraction</typeparam>
        /// <typeparam name="TSource">View model generic abstraction</typeparam>
        /// <param name="destination"></param>
        /// <returns></returns>
        public TDestination GetModel<TDestination, TSource>(TSource destination)
            where TDestination : class
            where TSource : class
        {
            this.CheckAgainsNoMaps();

            return mapper.Map<TSource, TDestination>(destination);
        }

        //public IQueryable<TDestination> Map<TDestination, TSource>(this IQueryable<TSource> query)
        //    where TDestination : class
        //    where TSource : class

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
            if(this.isConfigurationSettled == false)
            {
                throw new NoAppliedMappingsException();
            }
        }
    }
}
