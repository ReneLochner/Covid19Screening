using Covid19Screening.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Covid19Screening.Core.DTOs
{
    public class CampaignDto
    {
        public int Id { get; set; }
        public DateTime From { get; set; }
        public string Name { get; set; }
        public DateTime To { get; set; }

        public CampaignDto(Campaign campaign)
        {
            this.From = campaign.From;
            this.Name = campaign.Name;
            this.To = campaign.To;
        }
    }
}
