using Covid19Screening.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Covid19Screening.Core.Contracts
{
    public interface ICampaignRepository
    {
        Task<IEnumerable<CampaignDto>> GetAllAsync();
    }
}
