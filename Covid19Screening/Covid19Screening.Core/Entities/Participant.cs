using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Covid19Screening.Core.Entities
{
    public class Participant
    {
        [Required]
        [DisplayName("Vorname")]
        public string FirstName { get; set; }

        [Required]
        [DisplayName("Nachname")]
        public string LastName { get; set; }

        [Required]
        [DisplayName("Geburtsdatum")]
        public DateTime Birthdate { get; set; }

        [Required]
        [DisplayName("Geschlecht")]
        public int Gender { get; set; }

        [Required]
        [DisplayName("SVNr.")]
        public int SocialSecurityNumber { get; set; }

        [Required]
        [DisplayName("Handynummer")]
        public string MobileNumber { get; set; }

        [Required]
        [DisplayName("Straße")]
        public string Street { get; set; }

        [Required]
        [DisplayName("Hausnummer")]
        public int HouseNumber { get; set; }

        [Required]
        [DisplayName("Stiegennummer")]
        public int StairNumber { get; set; }

        [Required]
        [DisplayName("Türnummer")]
        public int DoorNumber { get; set; }

        [Required]
        [DisplayName("Postleitzahl")]
        public int Postcode { get; set; }

        [Required]
        [DisplayName("Ort")]
        public string City { get; set; }
    }
}
