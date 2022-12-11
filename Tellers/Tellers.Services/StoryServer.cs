using Microsoft.EntityFrameworkCore;
using Tellers.DataModels;
using Tellers.DbContext;
using Tellers.Mapper.Interfaces;
using Tellers.Services.Interfaces;
using Tellers.ViewModels.Story;

namespace Tellers.Services
{
    public class StoryServer : IStoryServer
    {
        private readonly TellersDbContext data;
        private readonly IMapWrapper mapper;

        public StoryServer(
            TellersDbContext data, 
            IMapWrapper mapper)
        {
            this.data = data;
            this.mapper = SetMappingConfiguration(mapper);
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

        private IMapWrapper SetMappingConfiguration(IMapWrapper mapper)
        {
            return mapper.CreateMap<StoryCardViewModel, Story>()
                .ApplyAllMaps();
        }
    }
}
