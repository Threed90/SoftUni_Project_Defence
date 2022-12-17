using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tellers.DataModels;
using Tellers.DbContext;
using Tellers.Mapper.Interfaces;
using Tellers.Services.Interfaces;
using Tellers.ViewModels.Genres;
using Tellers.ViewModels.StoryTypes;

namespace Tellers.Services
{
    public class StoryTypeService : IStoryTypeService
    {
        private readonly TellersDbContext data;
        private readonly IMapWrapper mapper;

        public StoryTypeService(
            TellersDbContext data,
            IMapWrapper mapper)
        {
            this.data = data;
            this.mapper = SetMappingConfiguration(mapper);
        }

        public async Task<IEnumerable<StoryTypeViewModel>> GetAll()
        {
            return this.mapper.GetModels<StoryTypeViewModel, StoryType>(await this.data.StoryTypes.OrderBy(st => st.Name).AsNoTracking().ToListAsync());

        }



        private IMapWrapper? SetMappingConfiguration(IMapWrapper mapper)
        {
            return mapper
                .CreateMap<StoryTypeViewModel, StoryType>()
                .ApplyAllMaps();
        }
    }
}
