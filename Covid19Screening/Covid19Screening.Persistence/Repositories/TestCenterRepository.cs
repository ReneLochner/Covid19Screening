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

        public async Task<TestCenter> GetByIdAsync(int id)
        {
            return await _dbContext
                .TestCenters
                .Include(testCenter => testCenter.AvailableInCampaigns)
                .SingleOrDefaultAsync(testCenter => testCenter.Id == id);
        }

        public async Task<TestCenter[]> GetByCampaignIdAsync(int campaignId)
        {
            var campaign = await _dbContext.Campaigns
                .Include(c => c.AvailableTestCenters)
                .SingleAsync(c => c.Id == campaignId);

            return campaign.AvailableTestCenters
                .OrderBy(c => c.Name)
                .ToArray();
        }

        public async Task<TestCenterDto[]> GetByPostalCodeAsync(int postalCode)
        {
            return await _dbContext.TestCenters
                .Where(testCenter => testCenter.Postalcode == postalCode)
                .Select(testCenter => new TestCenterDto
                {
                    Name = testCenter.Name,
                    SlotCapacity = testCenter.SlotCapacity,
                    Street = testCenter.Street,
                    Postalcode = testCenter.Postalcode,
                    City = testCenter.City
                })
                .ToArrayAsync();
        }

        public async Task AddAsync(TestCenter testCenter)
        {
            await _dbContext.TestCenters.AddAsync(testCenter);
        }

        public void Update(TestCenter testCenter)
        {
            _dbContext.TestCenters.Update(testCenter);
        }

        public void Remove(TestCenter testCenter)
        {
            _dbContext.TestCenters.Remove(testCenter);
        }
    }
}
