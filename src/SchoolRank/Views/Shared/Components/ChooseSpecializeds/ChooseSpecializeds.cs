using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TalentVN.ApplicationCore.Entities;
using TalentVN.Infrastructure.Data;

namespace TalentVN.SchoolRank.Views.Shared.Components.ChooseSpecializeds
{
    public class ChooseSpecializedsViewComponent: ViewComponent
    {
        private readonly AppDbContext _context;

        public ChooseSpecializedsViewComponent(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }

        public async Task<IViewComponentResult> InvokeAsync(
        string profileId, List<Specialized> specializeds)
        {
            var validSpecializeds = specializeds;

            var unValidSpecializeds = await GetUnValidItemsAsync(validSpecializeds);

            var chooseSpecializedsViewModel = new ChooseSpecializedsViewModel()
            {
                validSpecializeds = validSpecializeds,
                unValidSpecializeds = unValidSpecializeds
            };

            return View(chooseSpecializedsViewModel);
        }

        private async Task<List<Specialized>> GetUnValidItemsAsync(List<Specialized> validSpecializeds)
        {
            var specializeds = await _context.Specializeds.Where(x => !validSpecializeds.Contains(x)).ToListAsync();
            return specializeds;
        }

        private async Task<List<Specialized>> GetValidItemsAsync(string profileId)
        {
            var schoolProfile = await _context.SchoolProfiles
                .Include(x => x.Specializeds)
                .FirstOrDefaultAsync(m => m.Id == profileId);

            return schoolProfile.Specializeds.ToList();
        }


    }

    public class ChooseSpecializedsViewModel
    {
        public List<Specialized> validSpecializeds { get; set; }

        public List<Specialized> unValidSpecializeds { get; set; }
    }
}
