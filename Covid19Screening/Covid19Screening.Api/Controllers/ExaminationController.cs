using Covid19Screening.Core.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Covid19Screening.Api.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class ExaminationController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ExaminationController(IUnitOfWork uow)
        {
            _unitOfWork = uow;
        }

        /// <summary>
        /// Liefert alle Untersuchungen in einem Zeitraum
        /// </summary>
        /// <param name="from">Startpunkt</param>
        /// <param name="to">Endpunkt</param>
        /// <returns>examinationDto[]</returns>
        [HttpGet("{from}/{to}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetExaminationByTimeSpan(DateTime from, DateTime to)
        {
            if (from == null || to == null)
            {
                return BadRequest();
            }

            var examinations = await _unitOfWork.Examinations.GetFilteredByTimeSpan(from, to);

            if (examinations == null)
            {
                return NotFound();
            }

            return Ok(examinations);
        }
    }
}
