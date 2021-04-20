using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Covid19Screening.Core.DTOs
{
    public class CredentialDto
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string EmailAdress { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
