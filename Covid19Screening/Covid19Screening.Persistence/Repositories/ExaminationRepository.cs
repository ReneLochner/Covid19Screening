using Covid19Screening.Core.Contracts;
using Covid19Screening.Core.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Covid19Screening.Persistence.Repositories
{
    public class ExaminationRepository : IExaminationRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ExaminationRepository(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<ExaminationDto[]> GetFilteredExamination(DateTime from, DateTime to)
        {
            return await _dbContext.Examinations
               .Include(participant => participant.Participant)
               .Select(s => new ExaminationDto(s))
               .ToArrayAsync();
        }
    }
}
