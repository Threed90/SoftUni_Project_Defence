using Tellers.ViewModels.StoryTypes;

namespace Tellers.Services.Interfaces
{
    public interface IStoryTypeService
    {
        Task<IEnumerable<StoryTypeViewModel>> GetAll();
    }
}
