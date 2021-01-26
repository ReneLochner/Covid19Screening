using Covid19Screening.Persistence;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ImportController
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await InitDataAsync();

            Console.WriteLine();
            Console.Write("Beenden mit Eingabetaste ...");
            Console.ReadLine();
        }

        private static async Task InitDataAsync()
        {
            Console.WriteLine("***************************");
            Console.WriteLine("          Import");
            Console.WriteLine("***************************");
            Console.WriteLine("Import der Covid19Screening-Testdaten in die Datenbank");
            await using var unitOfWork = new UnitOfWork();
            Console.WriteLine("Datenbank löschen");
            await unitOfWork.DeleteDatabaseAsync();
            Console.WriteLine("Datenbank migrieren");
            await unitOfWork.MigrateDatabaseAsync();

            Console.WriteLine("Daten werden generiert.");
            var campaigns = ImportController.CreateCampaignTestData();
            var testCenters = ImportController.CreateTestCenterTestData();
            Console.WriteLine($"  {campaigns.Count()} Kampagnen generiert");
            Console.WriteLine($"  {testCenters.Count()} Test Center generiert");

            await unitOfWork.Campaigns.AddRangeAsync(campaigns);
            await unitOfWork.TestCenters.AddRangeAsync(testCenters);

            Console.WriteLine("Produkte werden in Datenbank gespeichert (persistiert)");
            await unitOfWork.SaveChangesAsync();
        }
    }
}
