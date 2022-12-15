﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tellers.DataModels;
using Tellers.DbContext;
using Tellers.Mapper.Interfaces;
using Tellers.Services.Interfaces;
using Tellers.ViewModels.Revues;
using Tellers.ViewModels.Story;

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