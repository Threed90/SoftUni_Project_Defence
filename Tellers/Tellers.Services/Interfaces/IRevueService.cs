using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tellers.ViewModels.Revues;

namespace Tellers.Services.Interfaces
{
    public interface IRevueService
    {
        Task CreateRevue(string storyId, string userId, string text, double rating);
        //Task<CreateRevueViewModel> GetRevue(string storyId, string userId, string text, double rating);
    }
}
