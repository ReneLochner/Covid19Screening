using Covid19Screening.Core.Contracts;
using Covid19Screening.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Covid19Screening.Persistence.Repositories
{
    public class CampaignRepository : ICampaignRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public CampaignRepository(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<IEnumerable<CampaignDto>> GetAllAsync()
        {
            return await _dbContext.Campaigns
                .OrderBy(campaign => campaign.Name)
                .Select(campaign => new CampaignDto(campaign))
                .ToListAsync();
        }
    }
}
