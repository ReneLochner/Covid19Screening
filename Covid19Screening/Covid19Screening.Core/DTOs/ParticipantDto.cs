using Covid19Screening.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Covid19Screening.Core.DTOs
{
    public class ParticipantDto
    {
        public int Id { get; set; }

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

        public ParticipantDto(Participant participant)
        {
            this.Id = participant.Id;
            this.FirstName = participant.FirstName;
            this.LastName = participant.LastName;
            this.Birthdate = participant.Birthdate;
            this.Gender = participant.Gender;
            this.SocialSecurityNumber = participant.SocialSecurityNumber;
            this.MobileNumber = participant.MobileNumber;
            this.Street = participant.Street;
            this.HouseNumber = participant.HouseNumber;
            this.StairNumber = participant.StairNumber;
            this.DoorNumber = participant.DoorNumber;
            this.Postcode = participant.Postcode;
            this.City = participant.City;
        }
    }
}
