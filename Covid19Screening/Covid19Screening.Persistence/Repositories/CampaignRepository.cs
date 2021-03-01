using Covid19Screening.Core.Contracts;
using Covid19Screening.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Covid19Screening.Core.Entities;

namespace Covid19Screening.Persistence.Repositories
{
    public class CampaignRepository : ICampaignRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public CampaignRepository(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task AddRangeAsync(IEnumerable<Campaign> campaigns)
        {
            await _dbContext.Campaigns.AddRangeAsync(campaigns);
        }

        public async Task<IEnumerable<CampaignDto>> GetAllAsync()
        {
            return await _dbContext.Campaigns
                .OrderBy(campaign => campaign.Name)
                .Select(campaign => new CampaignDto(campaign))
                .ToListAsync();
        }

        public async Task<Campaign> GetByIdAsync(int id)
        {
            return await _dbContext.Campaigns
                .SingleOrDefaultAsync(campaign => campaign.Id == id);
        }

        public async Task<CampaignDto> GetDtoByIdAsync(int id)
        {
            return await _dbContext.Campaigns
                .Select(campaign => new CampaignDto
                {
                    Id = campaign.Id,
                    Name = campaign.Name,
                    From = campaign.From,
                    To = campaign.To
                })
                .SingleOrDefaultAsync(campaign => campaign.Id == id);
        }

        public async Task AddAsync(Campaign campaign)
        {
            await _dbContext.Campaigns.AddAsync(campaign);
        }

        public void Update(Campaign campaign)
        {
            _dbContext.Campaigns.Update(campaign);
        }

        public void Remove(Campaign campaign)
        {
            _dbContext.Campaigns.Remove(campaign);
        }
    }
}
