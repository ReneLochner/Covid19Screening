using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Covid19Screening.Core.Contracts;
using Covid19Screening.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Covid19Screening.Web.Pages.Security
{
    public class VerificationModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        [BindProperty]
        [Required(ErrorMessage = "Der Token ist verpflichtend!")]
        [Range(100_000, 999_999, ErrorMessage = "Der Token muss 6-stellig sein!")]
        public int Token { get; set; }

        [BindProperty]
        public Guid VerificationIdentifier { get; set; }

        public VerificationModel(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public IActionResult OnGet(Guid verificationIdentifier)
        {
            VerificationIdentifier = verificationIdentifier;

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid verificationIdentifier)
        {
            VerificationToken verificationToken = await _unitOfWork.VerificationTokens.GetTokenByIdentifierAsync(verificationIdentifier);

            if (verificationToken.Token == Token && verificationToken.ValidUntil >= DateTime.Now)
            {
                return RedirectToPage("/Security/Success", new {verificationIdentifier = verificationToken.Identifier});
            }
            else
            {
                return RedirectToPage("/Security/TokenError");
            }
        }
    }
}
