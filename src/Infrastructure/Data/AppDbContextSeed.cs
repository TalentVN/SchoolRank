using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TalentVN.Infrastructure.Data
{
    public class AppDbContextSeed
    {
        public static async Task SeedAsync(AppDbContext appDbContext, ILoggerFactory loggerFactory)
        {

            try
            {
                // TODO: Only run this if using a real database
                // context.Database.Migrate();

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
