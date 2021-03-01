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
        public TestResults TestResult { get; set; }
        public DateTime ExaminationAt { get; set; }
        public string Identifier { get; set; }
        public string ParticipantFullName { get; set; }

        public ExaminationDto()
        {
        }

        public ExaminationDto(Examination examination)
        {
            this.Id = examination.Id;
            this.TestResult = examination.TestResult;
            this.ExaminationAt = examination.ExaminationAt;
            this.Identifier = examination.Identifier;
        }
    }
}
