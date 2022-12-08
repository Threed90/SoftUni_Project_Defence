using AutoMapper;
using AutoMapper.Configuration.Conventions;
using System.Linq.Expressions;

namespace Tellers.Mapper.Interfaces
{
    /// <summary>
    /// Interface for Automapper wrapper class creation.
    /// </summary>
    public interface IMapWrapper
    {
        /// <summary>
        /// Method for realization of mapping between two classes - from data model to view model.
        /// </summary>
        /// <typeparam name="TDestination"></typeparam>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="destination"></param>
        /// <returns></returns>
        public TDestination GetModel<TDestination, TSource>(TSource destination)
            where TDestination : class
            where TSource : class;

        /// <summary>
        /// Creating map between two objects. It is self chaning method. Request using of ApplyAllMaps() method to safe all of mapping configurations.
        /// </summary>
        /// <typeparam name="TDestination"></typeparam>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="destinationProperty"></param>
        /// <param name="sourceProperty"></param>
        /// <returns></returns>
        public IMapWrapper CreateMap<TDestination, TSource>(Expression<Func<TDestination>>? destinationProperty = null, Expression<Func<TSource>>? sourceProperty = null)
            where TDestination : class
            where TSource : class;

        /// <summary>
        /// Applying all configuration to inner AutoMapper
        /// </summary>
        /// <returns></returns>
        public IMapWrapper ApplyAllMaps();

        public IEnumerable<TDestination> GetModels<TDestination, TSource>(IEnumerable<TSource> destination)
            where TDestination : class
            where TSource : class;
        
        public IQueryable<TDestination> GetModelsAsIQueryable<TDestination, TSource>(IQueryable<TSource> destination)
            where TDestination : class
            where TSource : class;

        //public IConfigurationProvider GetConfig();
    }
}
