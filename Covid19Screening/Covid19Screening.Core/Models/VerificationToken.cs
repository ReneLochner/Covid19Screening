using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Covid19Screening.Core.Models
{
    public class VerificationToken
    {
        public int Id { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }
        public int Token { get; set; }

        public Guid Identifier { get; set; }
        public DateTime IssuedAt { get; set; }

        [NotMapped]
        public DateTime ValidUntil => IssuedAt.AddMinutes(15);

        public bool IsInvalidated { get; set; }

        public static VerificationToken NewToken()
        {
            return new VerificationToken()
            {
                Token = new Random().Next(100_000, 1_000_000),
                Identifier = Guid.NewGuid(),
                IssuedAt = DateTime.Now,
                IsInvalidated = false
            };
        }
    }
}
