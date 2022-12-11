using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tellers.DataSeeder.Interfaces;

namespace Tellers.DataSeeder
{
    public class DataSeeder : IDataSeeder
    {
        public void SeedAllNonRequiredData(ModelBuilder builder)
        {
           
        }

        public void SeedAllNonRequiredDataFromJSON(ModelBuilder builder, string json)
        {
           
        }

        public void SeedAllRequiredData(ModelBuilder builder)
        {
           
        }

        public void SeedAllRequiredDataFromJSON(ModelBuilder builder, string json)
        {
           
        }
    }
}
