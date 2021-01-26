using System;
using System.Collections.Generic;
using System.Text;

namespace Covid19Screening.Core.Entities
{
    public class Examination : EntityObject
    {
        public TestCenter ExaminationAt { get; set; }

        public static Examination CreateNew()
        {
            return new Examination();
        }
    }
}
