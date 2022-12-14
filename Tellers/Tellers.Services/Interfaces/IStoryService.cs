﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tellers.DataModels;
using Tellers.ViewModels.Story;

namespace Tellers.Services.Interfaces
{
    public interface IStoryService
    {
        Task<IEnumerable<StoryCardViewModel>> All();
        Task<IEnumerable<StoryCardViewModel>> GetNewestStories();
        Task<IEnumerable<StoryCardViewModel>> GetTopStories();
        Task<StoryDetailsViewModel> GetStoryDetails(string storyId);

    }
}