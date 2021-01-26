using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Covid19Screening.Core.Contracts;
using Covid19Screening.Core.DTOs;
using Covid19Screening.Core.Entities;
using Covid19Screening.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Covid19Screening.Web.Pages
{
    public class AddExaminationModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        [BindProperty]
        [Required(ErrorMessage = "Die {0} ist verpflichtend!")]
        [DisplayName("Kampagne")]
        public List<SelectListItem> Campaigns { get; set; } = new List<SelectListItem>();

        [BindProperty]
        [DisplayName("Campaign")]
        public int SelectedCampaignId { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Der {0} ist verpflichtend!")]
        [DisplayName("Untersuchungsort")]
        public List<SelectListItem> TestCenters { get; set; } = new List<SelectListItem>();

        [BindProperty]
        [DisplayName("Test Center")]
        public int SelectedTestCenterId { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Der {0} ist verpflichtend!")]
        [DisplayName("Datum")]
        public List<SelectListItem> CampaignDates { get; set; } = new List<SelectListItem>();

        [BindProperty]
        [DisplayName("Campaign Date")]
        public int SelectedCampaignDate { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Der {0} ist verpflichtend!")]
        [DisplayName("Zeitraum")]
        public string Timespans { get; set; }

        public AddExaminationModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> OnGet()
        {
            SelectedCampaignId = 0;
            await LoadCampaigns();
            await LoadTestCenters();
            
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            await LoadCampaigns();
            await LoadTestCenters();

            return Page();
        }

        public async Task LoadCampaigns()
        {
            var xxx = await _unitOfWork.Campaigns
                .GetAllAsync();

            Campaigns = (await _unitOfWork.Campaigns
                .GetAllAsync())
                .Select(campaign => new SelectListItem(
                    text: $"{campaign.Name}",
                    value: campaign.Id.ToString(),
                    selected: SelectedCampaignId == campaign.Id
                 ))
                .ToList();
        }

        public async Task LoadTestCenters()
        {
            TestCenters = (await _unitOfWork.TestCenters
                .GetAllAsync())
                .Select(testCenter => new SelectListItem(
                    text: $"{testCenter.Name}",
                    value: testCenter.Id.ToString()
                 ))
                .ToList();
        }
    }
}
