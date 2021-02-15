using System;
using static Covid19Screening.Core.Enums;
using System.Collections.Generic;
using System.Text;

namespace Covid19Screening.Core.Entities
{
    public class Examination : EntityObject
    {
        public Campaign Campaign { get; set; }
        public Participant Participant { get; set; }
        public TestCenter TestCenter { get; set; }
        public TestResults TestResult { get; set; }
        public ExaminationStates State { get; set; }
        public DateTime ExaminationAt { get; set; }
        public string Identifier { get; set; }

        public static Examination CreateNew()
        {
            return new Examination();
        }
    }
}
