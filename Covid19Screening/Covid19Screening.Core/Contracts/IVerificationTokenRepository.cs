using Covid19Screening.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Covid19Screening.Core.Contracts
{
    public interface IVerificationTokenRepository
    {
        Task<VerificationToken> GetTokenByIdentifierAsync(Guid identifier);
        Task AddAsync(VerificationToken token);
    }
}
