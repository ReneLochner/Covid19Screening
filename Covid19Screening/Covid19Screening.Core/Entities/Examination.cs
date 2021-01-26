using System;
using System.Collections.Generic;
using System.Text;

namespace Covid19Screening.Core.Entities
{
    public class Examination
    {
        public TestCenter ExaminationAt { get; set; }
        public int Id { get; set; }

        public static Examination CreateNew()
        {
            return new Examination();
        }
    }
}
