using Covid19Screening.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using static Covid19Screening.Core.Enums;

namespace Covid19Screening.Core.DTOs
{
    public class ExaminationDto
    {
        public int Id { get; set; }
        public string ParticipantFullName { get; set; }
        public TestResults TestResult { get; set; }
        public DateTime ExaminationAt { get; set; }
        public string Identifier { get; set; }

        public ExaminationDto(Examination examination)
        {
            this.Id = examination.Id;
            this.ParticipantFullName = $"{examination.Participant.FirstName} {examination.Participant.LastName}";
            this.TestResult = examination.TestResult;
            this.ExaminationAt = examination.ExaminationAt;
            this.Identifier = examination.Identifier;
        }
    }
}
