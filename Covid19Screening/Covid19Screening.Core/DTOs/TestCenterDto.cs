using Covid19Screening.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Covid19Screening.Core.DTOs
{
    public class TestCenterDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int SlotCapacity { get; set; }
        public string Street { get; set; }
        public int Postalcode { get; set; }
        public string City { get; set; }

        public TestCenterDto()
        {
        }

        public TestCenterDto(TestCenter testCenter)
        {
            this.Name = testCenter.Name;
            this.SlotCapacity = testCenter.SlotCapacity;
            this.Street = testCenter.Street;
            this.Postalcode = testCenter.Postalcode;
            this.City = testCenter.City;
        }
    }
}
