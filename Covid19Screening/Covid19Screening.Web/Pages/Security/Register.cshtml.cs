using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Covid19Screening.Core.DTOs;
using Covid19Screening.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static Covid19Screening.Core.Enums;

namespace Covid19Screening.Web.Pages.Security
{
    public class RegisterModel : PageModel
    {
        private readonly UserManager<Participant> _userManager;

        public ParticipantDto AuthUser { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Der {0} ist verpflichtend!")]
        [MinLength(2, ErrorMessage = "Der {0} muss mindestens 2 Zeichen lang sein!")]
        [MaxLength(255, ErrorMessage = "Der {0} darf maximal 255 Zeichen lang sein!")]
        [DisplayName("Vorname")]
        public string FirstName { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Der {0} ist verpflichtend!")]
        [MinLength(2, ErrorMessage = "Der {0} muss mindestens 2 Zeichen lang sein!")]
        [MaxLength(255, ErrorMessage = "Der {0} darf maximal 255 Zeichen lang sein!")]
        [DisplayName("Nachname")]
        public string LastName { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Das {0} ist verpflichtend!")]
        [DisplayName("Geburtsdatum")]
        public DateTime Birthdate { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Das {0} ist verpflichtend!")]
        [DisplayName("Geschlecht")]
        [EnumDataType(typeof(Gender))]
        public Gender Gender { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Die {0} ist verpflichtend!")]
        [StringLength(10, ErrorMessage = "Die {0} muss genau 10 Zeichen lang sein!", MinimumLength = 10)]
        [DisplayName("SVNr")]
        public string SocialSecurityNumber { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Die {0} ist verpflichtend!")]
        [StringLength(16, ErrorMessage = "Die {0} muss zwischen {1} und {2} Zeichen lang sein", MinimumLength = 5)]
        [DisplayName("Handynummer")]
        public string MobileNumber { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Die {0} ist verpflichtend!")]
        [MinLength(4, ErrorMessage = "Die {0} muss mindestens 4 Zeichen lang sein!")]
        [MaxLength(255, ErrorMessage = "Der {0} darf maximal 255 Zeichen lang sein!")]
        [DisplayName("Stra�e")]
        public string Street { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Die {0} ist verpflichtend!")]
        [MinLength(1, ErrorMessage = "Die {0} muss mindestens 1 Zeichen lang sein!")]
        [MaxLength(3, ErrorMessage = "Der {0} darf maximal 3 Zeichen lang sein!")]
        [DisplayName("Hausnummer")]
        public int HouseNumber { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Die {0} ist verpflichtend!")]
        [MinLength(1, ErrorMessage = "Die {0} muss mindestens 1 Zeichen lang sein!")]
        [MaxLength(3, ErrorMessage = "Der {0} darf maximal 3 Zeichen lang sein!")]
        [DisplayName("Stiegennummer")]
        public int StairNumber { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Die {0} ist verpflichtend!")]
        [MinLength(1, ErrorMessage = "Die {0} muss mindestens 1 Zeichen lang sein!")]
        [MaxLength(3, ErrorMessage = "Der {0} darf maximal 3 Zeichen lang sein!")]
        [DisplayName("T�rnummer")]
        public int DoorNumber { get; set; }

        [Required(ErrorMessage = "Die {0} ist verpflichtend!")]
        [StringLength(4, ErrorMessage = "Die {0} muss genau 4 Zeichen lang sein!", MinimumLength = 4)]
        [DisplayName("Postleitzahl")]
        public int Postcode { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Der {0} ist verpflichtend!")]
        [MinLength(2, ErrorMessage = "Die {0} muss mindestens 2 Zeichen lang sein!")]
        [MaxLength(255, ErrorMessage = "Der {0} darf maximal 255 Zeichen lang sein!")]
        [DisplayName("Ort")]
        public string City { get; set; }

        public RegisterModel(UserManager<Participant> userManager)
        {
            this._userManager = userManager;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var result = await _userManager.CreateAsync(
                    new Participant
                    {
                        FirstName = AuthUser.FirstName,
                        LastName = AuthUser.LastName,
                        Birthdate = AuthUser.Birthdate,
                        Gender = AuthUser.Gender,
                        SocialSecurityNumber = AuthUser.SocialSecurityNumber,
                        MobileNumber = AuthUser.MobileNumber,
                        Street = AuthUser.Street,
                        HouseNumber = AuthUser.HouseNumber,
                        StairNumber = AuthUser.StairNumber,
                        DoorNumber = AuthUser.DoorNumber,
                        Postcode = AuthUser.Postcode,
                        City = AuthUser.City
                    });

                if (!result.Succeeded)
                {
                    foreach (string error in result.Errors.Select(e => e.Description))
                    {
                        ModelState.AddModelError(string.Empty, error);
                    }
                }
                else
                {
                    return RedirectToPage("./Login");
                }
            }

            return Page();
        }
    }
}
