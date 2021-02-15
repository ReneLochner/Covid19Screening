using Covid19Screening.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Covid19Screening.Core.Contracts
{
    public interface IExaminationRepository
    {
        Task<ExaminationDto[]> GetFilteredExamination(DateTime from, DateTime to);
    }
}
