using Covid19Screening.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Covid19Screening.Persistence.Repositories
{
    public class ParticipantRepository : IParticipantRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ParticipantRepository(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
    }
}
