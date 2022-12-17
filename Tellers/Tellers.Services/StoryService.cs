using Microsoft.EntityFrameworkCore;
using Tellers.DataModels;
using Tellers.DbContext;
using Tellers.Mapper.Interfaces;
using Tellers.Services.Interfaces;
using Tellers.ViewModels.Genres;
using Tellers.ViewModels.Story;
using Tellers.ViewModels.StoryTypes;

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
        public IEnumerable<StoryFilterCardViewModel> All()
        {
            return this.mapper.GetModels<StoryFilterCardViewModel, Story>
                (data.Stories
                      .Include(s => s.Genres)
                      .Include(s => s.StoryType)
                      .Include(s => s.Creator)
                      .ThenInclude(c => c.User)
                      .AsNoTracking());
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
                //nonsence but just a secure meager
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

        public async Task<T> AddAllGenresAndStoryTypes<T>(T? model = null) where T : StoryFormViewModel
        {
            var genres = this.mapper.GetModels<GenreViewModel, Genre>(
                            await this.data.Genres
                                    .AsNoTracking()
                                    .OrderBy(g => g.Name)
                                    .ToListAsync());

            var storyTypes = this.mapper.GetModels<StoryTypeViewModel, StoryType>(
                                await this.data.StoryTypes
                                    .AsNoTracking()
                                    .OrderBy(g => g.Name)
                                    .ToListAsync());
            if (model != null)
            {
                model.Genres = genres.ToList();
                model.StoryTypes = storyTypes.ToList();

                return model;
            }

            T instance = (T)Activator.CreateInstance(typeof(T));

            instance.Genres = genres.ToList();
            instance.StoryTypes = storyTypes.ToList();

            return instance;
        }

        public async Task CreateStory(StoryFormViewModel model, string userId)
        {
            var story = new Story()
            {
                PdfFileUrl = model.BookPdf,
                BookCoverPicture = model.BookCover,
                ExternalAuthorName = model.ExternalAuthor,
                StorySummary = model.StorySummery,
                StoryTypeId = int.Parse(model.StoryType),
                Title = model.Title,
                CreatedOn = DateTime.Now,
            };

            var profile = await this.data.Profiles.FirstOrDefaultAsync(p => p.UserId.ToString() == userId);

            story.Creator = profile;

            if (model.GenresNames != null)
            {
                var genresNames = model.GenresNames.Split(", ", StringSplitOptions.RemoveEmptyEntries).ToList();

                var genres = await this.data.Genres.Where(g => genresNames.Contains(g.Name)).ToListAsync();

                foreach (var gr in genres)
                {
                    story.Genres.Add(gr);
                }
            }

            if (model.ExternalAuthor == null)
            {
                story.Authors.Add(profile);
            }

            await this.data.Stories.AddAsync(story);
            await this.data.SaveChangesAsync();
        }

        public async Task<StoryEditFormViewModel> GetStory(string storyId)
        {
            var story = await this.data.Stories
                .Include(s => s.Creator)
                .ThenInclude(c => c.User)
                .Include(s => s.Genres)
                .Include(s => s.StoryType)
                .FirstOrDefaultAsync(s => s.Id.ToString() == storyId);

            return this.mapper.GetModel<StoryEditFormViewModel, Story>(story);
        }

        public async Task Edit(StoryEditFormViewModel model)
        {
            var story = await this.data.Stories
                .Include(s => s.Genres)
                .Include(s => s.StoryType)
                .FirstOrDefaultAsync(s => s.Id.ToString() == model.StoryId);

            story.Title = model.Title;
            story.StorySummary = model.StorySummery;
            story.BookCoverPicture = model.BookCover;
            story.PdfFileUrl = model.BookPdf;
            story.StoryType.Id = int.Parse(model.StoryType);
            story.ExternalAuthorName = model.ExternalAuthor;

            foreach (var genreName in model.GenresNames.Split(", ", StringSplitOptions.RemoveEmptyEntries))
            {
                if (!story.Genres.Any(g => g.Name == genreName))
                {
                    var genre = await this.data.Genres.FirstOrDefaultAsync(g => g.Name == genreName);

                    story.Genres.Add(genre);
                    await this.data.SaveChangesAsync();
                }
            }

            await this.data.SaveChangesAsync();
        }

        public async Task<bool> IsStoryCreatorTheCurrentUser(string storyId, string userId)
        {
            var creatorId = await this.data.Stories
                .Where(s => s.Id.ToString().ToLower() == storyId)
                .Select(s => s.Creator.UserId.ToString().ToLower())
                .FirstOrDefaultAsync();

            return (userId == creatorId);
        }

        public async Task DeleteStory(string storyId)
        {
            var story = await this.data.Stories.FirstOrDefaultAsync(s => s.Id.ToString() == storyId);

            this.data.Stories.Remove(story);

            await this.data.SaveChangesAsync();
        }

        public async Task<List<StoryFilterCardViewModel>> GetAll(string? genre = null, string? storyType = null)
        {

            var genres = this.mapper.GetModels<GenreViewModel, Genre>(this.data.Genres.AsNoTracking());
            var storyTypes = this.mapper.GetModels<StoryTypeViewModel, StoryType>(this.data.StoryTypes.AsNoTracking());
            List<StoryFilterCardViewModel> resultSet;

            if ((genre == null || genre == "All") && (storyType == null || storyType == "All"))
            {
                resultSet = this.All().ToList();
            }
            else if (genre != null && storyType != null && genre != "All" && storyType != "All")
            {
                resultSet = this.All()
                        .Where(s => s.Genres.Select(g => g.Name).Contains(genre) && s.StoryType.Name == storyType)
                        .ToList();
            }
            else if (genre != null && genre != "All")
            {
                resultSet = this.All()
                        .Where(s => s.Genres.Select(g => g.Name).Contains(genre))
                        .ToList();
            }
            else
            {
                resultSet = this.All()
                        .Where(s => s.StoryType.Name == storyType)
                        .ToList();
            }

            return resultSet;
        }

        public async Task<List<StoryFilterCardViewModel>> GetMine(string userId, string? genre = null, string? storyType = null)
        {
            var stories = await this.GetAll(genre, storyType);  

            return stories.Where(s => s.CreatorUserId == userId).ToList();
        }

        public async Task<List<StoryFilterCardViewModel>> GetReaded(string userId, string? genre = null, string? storyType = null)
        {

            var profile = await this.data.Profiles
                .Include(p => p.MyReads)
                .ThenInclude(r => r.Creator)
                .ThenInclude(c => c.User)
                .FirstOrDefaultAsync(p => p.User.Id.ToString() == userId);

            return this.mapper.GetModels<StoryFilterCardViewModel, Story>(profile.MyReads).ToList();
        }
        private IMapWrapper SetMappingConfiguration(IMapWrapper mapper)
        {
            return mapper
                .CreateMap<GenreViewModel, Genre>()
                .CreateMap<StoryTypeViewModel, StoryType>()
                .CreateMap<StoryCardViewModel, Story>()
                .AddProfile<Revue>()
                .AddProfile<Story>()
                .ApplyAllMaps();
        }
    }
}
