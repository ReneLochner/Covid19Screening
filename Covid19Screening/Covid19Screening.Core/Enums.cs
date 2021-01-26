using System;
using System.ComponentModel.DataAnnotations;

namespace Covid19Screening.Core
{
    public class Enums
    {
        public enum Gender
        {
            [Display(Name = "Männlich")] Male = 1,
            [Display(Name = "Weiblich")] Female = 2,
            [Display(Name = "Divers")] Diverse = 3
        }

        public enum TestResults
        {
            [Display(Name = "Unbekannt")] Unknown = 1,
            [Display(Name = "Positiv")] Positive = 2,
            [Display(Name = "Negativ")] Negative = 3
        }

        public enum ExaminationStates
        {
            [Display(Name = "Neu")] New = 1,
            [Display(Name = "Registriert")] Registered = 2,
            [Display(Name = "Getestet")] Tested = 3
        }
    }
}
