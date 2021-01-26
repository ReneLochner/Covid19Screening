using System;
using System.Collections.Generic;
using System.Text;

namespace Covid19Screening.Core.Entities
{
    public class Campaign : EntityObject
    {
        List<TestCenter> AvailableTestCenters { get; set; }
        public DateTime From { get; set; }
        public string Name { get; set; }
        public DateTime To { get; set; }
    }
}
