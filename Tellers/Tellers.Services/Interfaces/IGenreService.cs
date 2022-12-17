using Tellers.ViewModels.Genres;

namespace Tellers.Services.Interfaces
{
    public interface IGenreService
    {
        Task<IEnumerable<GenreViewModel>> GetAll();
    }
}
