using Covid19Screening.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ImportController
{
    public class ImportController
    {
        public static IEnumerable<Campaign> CreateCampaignTestData()
        {
            List<Campaign> campaigns = new List<Campaign>();
            campaigns.Add(new Campaign
            {
                Name = "Testkampagne 1",
                From = DateTime.Parse("25-01-2021"),
                To = DateTime.Parse("31-01-2021")
            });
            campaigns.Add(new Campaign
            {
                Name = "Testkampagne 2",
                From = DateTime.Parse("18-01-2021"),
                To = DateTime.Parse("24-01-2021")
            });

            return campaigns;
        }
        public static IEnumerable<TestCenter> CreateTestCenterTestData()
        {
            List<TestCenter> testCenters = new List<TestCenter>();
            testCenters.Add(new TestCenter
            { 
                Name = "Test Center 1",
                SlotCapacity = 8,
                Street = "Teststraße 1",
                Postalcode = 1234,
                City = "Testcity"
            });
            testCenters.Add(new TestCenter
            {
                Name = "Test Center 2",
                SlotCapacity = 15,
                Street = "Teststraße 2",
                Postalcode = 2345,
                City = "Testlocation"
            });

            return testCenters;
        }
    }
}
