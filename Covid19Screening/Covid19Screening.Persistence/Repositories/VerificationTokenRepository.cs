using Covid19Screening.Core.Contracts;
using Covid19Screening.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Covid19Screening.Persistence.Repositories
{
    public class VerificationTokenRepository : IVerificationTokenRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public VerificationTokenRepository(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task AddAsync(VerificationToken token)
            => await _dbContext
                .VerificationTokens
                .AddAsync(token);

        public async Task<VerificationToken> GetTokenByIdentifierAsync(Guid identifier)
            => await _dbContext
                .VerificationTokens
                .SingleAsync(verificationToken => verificationToken.Identifier == identifier);
    }
}
