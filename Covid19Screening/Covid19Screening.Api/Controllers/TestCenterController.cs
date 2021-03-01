using Covid19Screening.Core.Contracts;
using Covid19Screening.Core.DTOs;
using Covid19Screening.Core.Entities;
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
    public class TestCenterController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public TestCenterController(IUnitOfWork uow)
        {
            _unitOfWork = uow;
        }

        /// <summary>
        /// Liefert alle vorhandenen TestCenter
        /// </summary>
        /// <returns>TestCenterDto[]</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetTestCenter()
        {
            return Ok(await _unitOfWork.TestCenters.GetAllAsync());
        }

        /// <summary>
        /// Hinzufügen eines neuen TestCenters
        /// </summary>
        /// <param name="testCenterDto">TestCenterDto</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> AddTestCenter(TestCenterDto testCenterDto)
        {
            if (testCenterDto == null)
            {
                return BadRequest();
            }

            var newTestCenter = new TestCenter
            {
                City = testCenterDto.City,
                SlotCapacity = testCenterDto.SlotCapacity,
                Street = testCenterDto.Street,
                Name = testCenterDto.Name,
                Postalcode = testCenterDto.Postalcode
            };

            try
            {
                await _unitOfWork.TestCenters.AddAsync(newTestCenter);
                await _unitOfWork.SaveChangesAsync();

                return CreatedAtAction(
                    nameof(GetTestCenter),
                    new { id = newTestCenter.Id },
                    newTestCenter);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Liefert alle vorhandenen TestCenter eines bestimmten Bezirks
        /// </summary>
        /// <param name="postalCode">Postleitzahl</param>
        /// <returns>TestCenterDto[]</returns>
        [HttpGet("byPostalCode/{postalCode}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetTestCenterByPostalCode(int postalCode)
        {
            var testCenters = await _unitOfWork.TestCenters.GetByPostalCodeAsync(postalCode);

            if (testCenters == null)
            {
                return NotFound();
            }

            return Ok(testCenters);
        }

        /// <summary>
        /// Abfrage eines bestimmten TestCenters
        /// </summary>
        /// <param name="id">testCenterId</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetTestCenterById(int id)
        {
            var testCenter = await _unitOfWork.TestCenters.GetByIdAsync(id);

            if (testCenter == null)
            {
                return NotFound();
            }

            return Ok(testCenter);
        }

        /// <summary>
        /// Änderung eines TestCenters
        /// </summary>
        /// <param name="id">testCenterId</param>
        /// <param name="testCenterDto">testCenterDto</param>
        /// <returns>testCenterId</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateTestCenter(int id, TestCenterDto testCenterDto)
        {
            var testCenterInDb = await _unitOfWork.TestCenters.GetByIdAsync(id);

            if (testCenterInDb != null)
            {
                testCenterInDb.City = testCenterDto.City;
                testCenterInDb.SlotCapacity = testCenterDto.SlotCapacity;
                testCenterInDb.Street = testCenterDto.Street;
                testCenterInDb.Name = testCenterDto.Name;
                testCenterInDb.Postalcode = testCenterDto.Postalcode;

                try
                {
                    _unitOfWork.TestCenters.Update(testCenterInDb);
                    return Ok(await _unitOfWork.SaveChangesAsync());
                }
                catch (Exception e)
                {
                    return BadRequest(e.Message);
                }
            }
            else
            {
                return NotFound();
            }
        }

        /// <summary>
        /// Löschen eines TestCenters
        /// </summary>
        /// <param name="id">testCenterId</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> RemoveTestCenter(int id)
        {
            var testCenter = await _unitOfWork.TestCenters.GetByIdAsync(id);

            if (testCenter != null)
            {
                try
                {
                    _unitOfWork.TestCenters.Remove(testCenter);
                    return Ok(await _unitOfWork.SaveChangesAsync());
                }
                catch (Exception e)
                {
                    return BadRequest(e.Message);
                }
            }
            else
            {
                return NotFound();
            }
        }

        /// <summary>
        /// Liefert alle Untersuchungen zu einem TestCenter
        /// </summary>
        /// <param name="id">testCenterId</param>
        /// <returns></returns>
        [HttpGet("{id}/Examinations")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetExaminationsByTestCenterId(int id)
        {
            var examinations = await _unitOfWork.Examinations.GetByTestCenterIdAsync(id);

            if (examinations == null)
            {
                return NotFound();
            }

            return Ok(examinations);
        }
    }
}
