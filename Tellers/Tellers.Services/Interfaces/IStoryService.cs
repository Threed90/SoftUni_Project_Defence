using Tellers.ViewModels.Story;

namespace Tellers.Services.Interfaces
{
    public interface IStoryService
    {
        Task<IEnumerable<StoryCardViewModel>> All();
        Task<IEnumerable<StoryCardViewModel>> GetNewestStories();
        Task<IEnumerable<StoryCardViewModel>> GetTopStories();
        Task<StoryDetailsViewModel> GetStoryDetails(string storyId, int page, bool isMarked);
        Task<bool> MarkAsReaded(string storyId, string userId);
        Task<bool> IsReadedStory(string storyId, string userId);
    }
}
