using Microsoft.EntityFrameworkCore;
using Tellers.DataModels;
using Tellers.DbContext;
using Tellers.Mapper.Interfaces;
using Tellers.Services.Interfaces;
using Tellers.ViewModels.Revues;

namespace Tellers.Services
{
    public class RevueService : IRevueService
    {
        private readonly TellersDbContext data;
        private readonly IMapWrapper mapper;

        public RevueService(
            TellersDbContext data,
            IMapWrapper mapper)
        {
            this.data = data;
            this.mapper = this.SetMappingConfiguration(mapper);
        }

        public async Task CreateRevue(string storyId, string userId, string text, double rating)
        {
            var profile = await data.Profiles
                .FirstOrDefaultAsync(p => p.User.Id.ToString() == userId);

            Revue revue = new Revue()
            {
                Profile = profile,
                StoryId = new Guid(storyId),
                CreatedOn = DateTime.Now,
                Rating = rating,
                Text = text
            };

            await this.data.Revues.AddAsync(revue);

            await this.data.SaveChangesAsync();
        }

        public async Task<EditRevueViewModel> GetRevueForEditing(int revueId)
        {
            return this.mapper.GetModel<EditRevueViewModel, Revue>(
                    await this.data.Revues
                        .FirstOrDefaultAsync(r => r.Id == revueId));
        }

        public async Task EditRevue(int revueId, string text, double rating)
        {
            var revue = await this.data.Revues.FirstOrDefaultAsync(r => r.Id == revueId);

            revue.Text = text;
            revue.Rating = rating;
            await this.data.SaveChangesAsync();
        }

        public async Task DeleteRevue(int revueId)
        {
            var revue = await this.data.Revues.FirstOrDefaultAsync(r => r.Id == revueId);

            if (revue != null)
                this.data.Revues.Remove(revue);

            await this.data.SaveChangesAsync();
        }

        public async Task<string> GetRevueCreatorId(int revueId)
        {
            return this.data.Revues.Where(r => r.Id == revueId).Select(r => r.Profile.User.Id.ToString().ToLower()).FirstOrDefault();
        }

        //public Task<CreateRevueViewModel> GetRevue(string storyId, string userId, string text, double rating)
        //{
        //    throw new NotImplementedException();
        //}

        private IMapWrapper SetMappingConfiguration(IMapWrapper mapper)
        {
            return mapper
                .AddProfile<Revue>()
                .ApplyAllMaps();
        }
    }
}
