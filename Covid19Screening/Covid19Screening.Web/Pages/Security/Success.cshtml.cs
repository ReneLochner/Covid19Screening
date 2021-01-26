using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Covid19Screening.Core.Contracts;
using Covid19Screening.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Covid19Screening.Web.Pages.Security
{
    public class SuccessModel : PageModel
    {
        private IUnitOfWork _unitOfWork;

        public SuccessModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> OnGetAsync(Guid verificationIdentifier)
        {
            VerificationToken verificationToken = await _unitOfWork.VerificationTokens.GetTokenByIdentifierAsync(verificationIdentifier);

            if (verificationToken?.Identifier == verificationIdentifier && verificationToken.ValidUntil >= DateTime.Now)
            {
                return RedirectToPage("/Overview", new { verificationIdentifier = verificationToken.Identifier });
            }
            else
            {
                return RedirectToPage("/Security/TokenError");
            }
        }
    }
}
