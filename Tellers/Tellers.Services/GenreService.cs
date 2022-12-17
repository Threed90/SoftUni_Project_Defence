using Microsoft.EntityFrameworkCore;
using Tellers.DataModels;
using Tellers.DbContext;
using Tellers.Mapper.Interfaces;
using Tellers.Services.Interfaces;
using Tellers.ViewModels.Genres;

namespace Tellers.Services
{
    public class GenreService : IGenreService
    {
        private readonly TellersDbContext data;
        private readonly IMapWrapper mapper;

        public GenreService(
            TellersDbContext data,
            IMapWrapper mapper)
        {
            this.data = data;
            this.mapper = SetMappingConfiguration(mapper);
        }

        public async Task<IEnumerable<GenreViewModel>> GetAll()
        {
            return this.mapper.GetModels<GenreViewModel, Genre>(await this.data.Genres.OrderBy(g => g.Name).AsNoTracking().ToListAsync());
                
        }



        private IMapWrapper? SetMappingConfiguration(IMapWrapper mapper)
        {
            return mapper
                .CreateMap<GenreViewModel, Genre>()
                .ApplyAllMaps();
        }
    }
}
