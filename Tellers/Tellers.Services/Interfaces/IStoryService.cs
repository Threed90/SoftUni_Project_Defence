using Tellers.ViewModels.Story;

namespace Tellers.Services.Interfaces
{
    public interface IStoryService
    {
        IEnumerable<StoryFilterCardViewModel> All();
        Task<IEnumerable<StoryCardViewModel>> GetNewestStories();
        Task<IEnumerable<StoryCardViewModel>> GetTopStories();
        Task<StoryDetailsViewModel> GetStoryDetails(string storyId, int page, bool isMarked);
        Task<bool> MarkAsReaded(string storyId, string userId);
        Task<bool> IsReadedStory(string storyId, string userId);
        Task<T> AddAllGenresAndStoryTypes<T>(T? model = null) where T : StoryFormViewModel;
        Task CreateStory(StoryFormViewModel model, string userId);
        Task<StoryEditFormViewModel> GetStory(string storyId);
        Task Edit(StoryEditFormViewModel model);
        Task<bool> IsStoryCreatorTheCurrentUser(string storyId, string userId);
        Task DeleteStory(string storyId);
        Task<List<StoryFilterCardViewModel>> GetAll(string? genre = null, string? storyType = null);
        Task<List<StoryFilterCardViewModel>> GetMine(string userId, string? genre = null, string? storyType = null);
        Task<List<StoryFilterCardViewModel>> GetReaded(string userId, string? genre = null, string? storyType = null);

    }
}
