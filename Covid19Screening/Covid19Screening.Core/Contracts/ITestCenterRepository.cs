﻿using Covid19Screening.Core.DTOs;
using Covid19Screening.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Covid19Screening.Core.Contracts
{
    public interface ITestCenterRepository
    {
        Task AddRangeAsync(IEnumerable<TestCenter> testCenters);
        Task<IEnumerable<TestCenterDto>> GetAllAsync();
    }
}
