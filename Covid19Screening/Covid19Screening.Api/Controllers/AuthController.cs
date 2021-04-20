using Covid19Screening.Core.DTOs;
using Covid19Screening.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Covid19Screening.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly UserManager<Participant> _userManager;

        public AuthController(
            IConfiguration configuration,
            UserManager<Participant> userManager)
        {
            _config = configuration;
            _userManager = userManager;
        }

        [Route("login")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> LoginAsync([FromBody] CredentialDto credentials)
        {
            var authUser = await _userManager.FindByNameAsync(credentials.EmailAdress);

            if (authUser == null)
            {
                return Unauthorized();
            }

            if (!await _userManager.CheckPasswordAsync(authUser, credentials.Password))
            {
                return Unauthorized();
            }

            var tokenString = GenerateJwtToken(authUser.SocialSecurityNumber.ToString(), await _userManager.GetRolesAsync(authUser));

            return Ok(new
            {
                auth_token = tokenString,
                name = authUser.FullName,
            });

        }

        private string GenerateJwtToken(string socialSecurityNumber, IEnumerable<string> roles)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:SecretKey"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.SerialNumber, socialSecurityNumber)
            };

            foreach (string role in roles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, role));
            }

            var token = new JwtSecurityToken(
              issuer: _config["Jwt:Issuer"],
              audience: _config["Jwt:Audience"],
              claims: authClaims,
              expires: DateTime.Now.AddMinutes(30),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        [Route("register")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Register(ParticipantDto newParticipant)
        {
            var user = await _userManager.FindByNameAsync(newParticipant.SocialSecurityNumber.ToString());

            if (user != null)
            {
                return BadRequest(new { Status = "Error", Message = "User already exists!" });
            }

            var result = await _userManager.CreateAsync(new Participant
            {
                FirstName = newParticipant.FirstName,
                LastName = newParticipant.LastName,
                Birthdate = newParticipant.Birthdate,
                Gender = newParticipant.Gender,
                SocialSecurityNumber = newParticipant.SocialSecurityNumber,
                MobileNumber = newParticipant.MobileNumber,
                Street = newParticipant.Street,
                HouseNumber = newParticipant.HouseNumber,
                StairNumber = newParticipant.StairNumber,
                DoorNumber = newParticipant.DoorNumber,
                Postcode = newParticipant.Postcode,
                City = newParticipant.City
            });

            if (!result.Succeeded)
            {
                return BadRequest(new { Status = "Error", Message = string.Join(", ", result.Errors.Select(e => e.Description)) });
            }

            return Ok();
        }
    }
}
