using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Covid19Screening.Core.Contracts;
using Covid19Screening.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Covid19Screening.Web.Pages.Security
{
    public class LoginModel : PageModel
    {
        private readonly ISmsService _smsService;
        private readonly IUnitOfWork _unitOfWork;

        [BindProperty]
        [Required(ErrorMessage = "Die {0} ist verpflichtend!")]
        [StringLength(10, ErrorMessage = "Die {0} muss genau 10 Zeichen lang sein", MinimumLength = 10)]
        [DisplayName("SVNr")]
        public string SocialSecurityNumber { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Die {0} ist verpflichtend!")]
        [StringLength(16, ErrorMessage = "Die {0} muss zwischen {1} und {2} Zeichen lang sein", MinimumLength = 5)]
        [DisplayName("Handynummer")]
        public string MobileNumber { get; set; }

        public LoginModel(ISmsService smsService, IUnitOfWork unitOfWork)
        {
            this._smsService = smsService;
            this._unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }

            if(SocialSecurityNumber != "0000000000") // ToDo
            {
                ModelState.AddModelError(nameof(SocialSecurityNumber), "Diese SVNr. ist unbekannt!");
                return Page();
            }

            VerificationToken verificationToken = VerificationToken.NewToken();

            await _unitOfWork.VerificationTokens.AddAsync(verificationToken);
            await _unitOfWork.SaveChangesAsync();

            _smsService.SendSms(MobileNumber, $"Covid19-Screening Token: {verificationToken.Token}");

            return RedirectToPage("/Security/Verification", new { verificationIdentifier = verificationToken.Identifier });
        }
    }
}
