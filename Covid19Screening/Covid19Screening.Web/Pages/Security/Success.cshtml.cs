using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Covid19Screening.Web.Pages.Security
{
    public class SuccessModel : PageModel
    {
        public void OnGet(Guid verificationIdentifier)
        {
            // ToDo: Token verifizieren (basisklasse implementieren vom PageModel ableiten und allgemeine Methoden implementieren, dass der Token automatisch verifiziert wird
            // Aus Datenbank �ber VerificationIdentifier den VerificationToken holen - ist er noch g�ltig - im Fehlerfall umleiten, wenn Token noch g�ltig => Daten laden welche f�r Seite relevant sind
        }
    }
}
