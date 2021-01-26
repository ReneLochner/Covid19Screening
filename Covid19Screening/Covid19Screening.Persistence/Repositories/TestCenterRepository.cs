using Covid19Screening.Core.Contracts;
using Covid19Screening.Core.DTOs;
using Covid19Screening.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Covid19Screening.Persistence.Repositories
{
    public class TestCenterRepository : ITestCenterRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public TestCenterRepository(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task AddRangeAsync(IEnumerable<TestCenter> testCenters)
        {
            await _dbContext.TestCenters.AddRangeAsync(testCenters);
        }

        public async Task<IEnumerable<TestCenterDto>> GetAllAsync()
        {
            return await _dbContext.TestCenters
                .OrderBy(testCenter => testCenter.Name)
                .Select(testCenter => new TestCenterDto(testCenter))
                .ToListAsync();
        }
    }
}
