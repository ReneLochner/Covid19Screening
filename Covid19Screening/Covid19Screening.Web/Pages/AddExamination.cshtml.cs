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

namespace Covid19Screening.Web.Pages
{
    public class AddExaminationModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        [BindProperty]
        [Required(ErrorMessage = "Die {0} ist verpflichtend!")]
        [DisplayName("Kampagne")]
        public IEnumerable<CampaignDto> Campaigns { get; set; } = Enumerable.Empty<CampaignDto>();

        [BindProperty]
        [Required(ErrorMessage = "Der {0} ist verpflichtend!")]
        [DisplayName("Untersuchungsort")]
        public List<TestCenter> TestCenters { get; set; } = new List<TestCenter>();

        [BindProperty]
        [Required(ErrorMessage = "Der {0} ist verpflichtend!")]
        [DisplayName("Datum")]
        public List<DateTime> Dates { get; set; } = new List<DateTime>();

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
            Campaigns = await _unitOfWork.Campaigns.GetAllAsync();

            return Page();
        }

        public void OnPost()
        {

        }
    }
}
