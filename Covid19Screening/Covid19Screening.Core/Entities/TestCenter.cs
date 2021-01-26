using System;
using System.Collections.Generic;
using System.Text;

namespace Covid19Screening.Core.Entities
{
    public class TestCenter : EntityObject
    {
        public Campaign AvailableInCampaigns { get; set; }
        public string Name { get; set; }
        public int SlotCapacity { get; set; }
        public string Street { get; set; }
        public int Postalcode { get; set; }
        public string City { get; set; }
    }
}
