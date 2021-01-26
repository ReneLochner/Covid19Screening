using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Covid19Screening.Core.Contracts
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        ICampaignRepository Campaigns { get; }
        IExaminationRepository Examinations { get; }
        IParticipantRepository Participants { get; }
        ITestCenterRepository TestCenters { get; }
        IVerificationTokenRepository VerificationTokens { get; }

        Task<int> SaveChangesAsync();
        Task DeleteDatabaseAsync();
        Task MigrateDatabaseAsync();
        Task CreateDatabaseAsync();
    }
}
