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
        /// <typeparam name="TDataModel"></typeparam>
        /// <typeparam name="TViewModel"></typeparam>
        /// <param name="dataModel"></param>
        /// <returns></returns>
        public TViewModel GetModel<TDataModel, TViewModel>(TDataModel dataModel)
            where TViewModel : class
            where TDataModel : class;
    }
}
