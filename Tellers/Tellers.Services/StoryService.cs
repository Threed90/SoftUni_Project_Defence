using Microsoft.EntityFrameworkCore;
using Tellers.DataModels;
using Tellers.DbContext;
using Tellers.Mapper.Interfaces;
using Tellers.Services.Interfaces;
using Tellers.ViewModels.Story;

namespace Tellers.Services
{
    public class StoryService : IStoryService
    {
        private readonly TellersDbContext data;
        private readonly IMapWrapper mapper;
        private readonly IProfileService profileService;

        public StoryService(
            TellersDbContext data,
            IMapWrapper mapper,
            IProfileService profileService)
        {
            this.data = data;
            this.mapper = SetMappingConfiguration(mapper);
            this.profileService = profileService;
        }

        /// <summary>
        /// Service method that returns all stories as no tracking set and returns need view model via map wrapper.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<StoryCardViewModel>> All()
        {
            return this.mapper.GetModels<StoryCardViewModel, Story>
                (await data.Stories
                      .AsNoTracking()
                      .ToListAsync());
        }

        public async Task<IEnumerable<StoryCardViewModel>> GetNewestStories()
        {
            return this.mapper.GetModels<StoryCardViewModel, Story>
                (await data
                       .Stories
                       .OrderByDescending(s => s.CreatedOn)
                       .Take(9)
                       .ToListAsync());
        }

        public async Task<IEnumerable<StoryCardViewModel>> GetTopStories()
        {
            return this.mapper.GetModels<StoryCardViewModel, Story>
                (await this.data.Stories
                            .Include(s => s.Revues)
                            .ThenInclude(r => r.Profile)
                            .Include(s => s.Authors)
                            .Include(s => s.Genres)
                            .Include(s => s.Creator)
                            .Include(s => s.StoryType)
                            .Include(s => s.Readers)
                            .AsNoTracking()
                            .OrderByDescending(s => s.Readers.Count)
                            .ThenByDescending(s => s.Revues.Count)
                            .ThenByDescending(s => s.Revues.Average(r => r.Rating))
                            .ThenBy(s => s.Creator.FirstName)
                            .ThenBy(s => s.Creator.LastName)
                            .Take(9)
                            .ToListAsync());
        }

        public async Task<StoryDetailsViewModel> GetStoryDetails(string storyId, int page, bool isMarked)
        {
            var storyDetail = this.mapper.GetModel<StoryDetailsViewModel, Story>
                        (await this.data.Stories
                        .Include(s => s.Creator)
                        .ThenInclude(c => c.User)
                        .Include(s => s.Revues)
                        .ThenInclude(r => r.Profile)
                        .ThenInclude(p => p.User)
                        .Include(s => s.Authors)
                        .Include(s => s.StoryType)
                        .Include(s => s.Genres)
                        .FirstOrDefaultAsync(s => s.Id.ToString() == storyId));

            var skip = (page - 1) * 5;
            var take = (page) * 5;

            storyDetail.Revues = storyDetail.Revues.Skip(skip).Take(take).ToList();

            storyDetail.Page = page;
            storyDetail.IsMarkedAsReaded = isMarked;

            return storyDetail;
        }

        public async Task<bool> MarkAsReaded(string storyId, string userId)
        {
            var profile = await this.data.Profiles
                .Include(p => p.MyReads)
                .FirstOrDefaultAsync(p => p.User.Id.ToString() == userId);

            var story = await this.data.Stories
                .FirstOrDefaultAsync(s => s.Id.ToString() == storyId);

            if (story == null && profile == null)
            {
                //nonsence but just a secure meger
                return false;
            }
                if (profile?.MyReads.Any(s => s.Id == story?.Id) ?? false)
            {
                profile.MyReads.Remove(story);
                await data.SaveChangesAsync();
                return false;
            }
            else
            {
                profile.MyReads.Add(story);
                await data.SaveChangesAsync();
                return true;
            }
        }

        public async Task<bool> IsReadedStory(string storyId, string userId)
        {
            var profile = await this.data.Profiles
                .Include(p => p.MyReads)
                .FirstOrDefaultAsync(p => p.User.Id.ToString() == userId);

            var story = await this.data.Stories
                .FirstOrDefaultAsync(s => s.Id.ToString() == storyId);

            if (profile?.MyReads.Any(s => s.Id == story?.Id) ?? false)
            {
                return true;
            }

            return false;
        }

        private IMapWrapper SetMappingConfiguration(IMapWrapper mapper)
        {
            return mapper
                .CreateMap<StoryCardViewModel, Story>()
                //.CreateMap<StoryDetailsViewModel, Story>()
                .AddProfile<Revue>()
                .AddProfile<Story>()
                .ApplyAllMaps();
        }
    }
}
