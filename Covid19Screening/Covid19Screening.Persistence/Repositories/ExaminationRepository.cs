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

        public async Task<ExaminationDto[]> GetFilteredByTimeSpan(DateTime from, DateTime to)
        {
            var query = _dbContext.Examinations.AsQueryable();

            query = query.Where(examination => examination.ExaminationAt.Date >= from.Date);
            query = query.Where(examination => examination.ExaminationAt.Date <= to.Date);

            return await query
                .OrderBy(examination => examination.ExaminationAt)
                .Select(examination => new ExaminationDto
                {
                    Id = examination.Id,
                    TestResult = examination.TestResult,
                    ExaminationAt = examination.ExaminationAt,
                    Identifier = examination.Identifier,
                    ParticipantFullName = examination.Participant.FullName
                })
                .ToArrayAsync();
        }

        public async Task<ExaminationDto[]> GetByCampaignIdAsync(int campaignId)
        {
            return await _dbContext.Examinations
                .Where(examination => examination.Campaign.Id == campaignId)
                .Select(examination => new ExaminationDto
                {
                    Id = examination.Id,
                    TestResult = examination.TestResult,
                    ExaminationAt = examination.ExaminationAt,
                    Identifier = examination.Identifier
                })
                .ToArrayAsync();
        }

        public async Task<ExaminationDto[]> GetByTestCenterIdAsync(int id)
        {
            return await _dbContext.Examinations
                 .Where(testCenter => testCenter.TestCenter.Id == id)
                 .Select(examination => new ExaminationDto
                 {
                     Id = examination.Id,
                     TestResult = examination.TestResult,
                     ExaminationAt = examination.ExaminationAt,
                     Identifier = examination.Identifier
                 })
                 .ToArrayAsync();
        }
    }
}
