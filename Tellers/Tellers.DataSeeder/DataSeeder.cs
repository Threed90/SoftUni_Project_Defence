using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Tellers.DataModels;
using Tellers.DataSeeder.Interfaces;
using Tellers.DbContext;

namespace Tellers.DataSeeder
{
    public class DataSeeder : IDataSeeder
    {
        public void SeedAllNonRequiredData(TellersDbContext context)
        {
            var countries = this.GetModels<Country>("Countries.json");

            if (context.Countries.Any() == false)
            {
                context.Countries.AddRange(countries);
            }

            var towns = this.GetModels<Town>("Towns.json");

            if (context.Towns.Any() == false)
            {
                context.Towns.AddRange(towns);
            }

            context.SaveChanges();
        }

        public void SeedAllRequiredData(TellersDbContext context)
        {
            var genres = this.GetModels<Genre>("Genres.json");

            if (context.Genres.Any() == false)
            {
                context.Genres.AddRange(genres);
            }

            var storyTypes = this.GetModels<StoryType>("StoryTypes.json");

            if (context.StoryTypes.Any() == false)
            {
                context.StoryTypes.AddRange(storyTypes);
            }
        }

        private IEnumerable<TEntity> GetModels<TEntity>(string fileName)
        {
            var json = File.ReadAllText($@"./JSON/{fileName}");
            var models = JsonSerializer.Deserialize<IEnumerable<TEntity>>(json);

            return models;
        }
    }
}
