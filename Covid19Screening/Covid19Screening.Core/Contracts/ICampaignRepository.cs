using Covid19Screening.Core.DTOs;
using Covid19Screening.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Covid19Screening.Core.Contracts
{
    public interface ICampaignRepository
    {
        Task AddRangeAsync(IEnumerable<Campaign> campaigns);
        Task<IEnumerable<CampaignDto>> GetAllAsync();
        Task<Campaign> GetByIdAsync(int id);
        Task<CampaignDto> GetDtoByIdAsync(int id);
        Task AddAsync(Campaign campaign);
        void Update(Campaign campaign);
        void Remove(Campaign campaign);
    }
}
