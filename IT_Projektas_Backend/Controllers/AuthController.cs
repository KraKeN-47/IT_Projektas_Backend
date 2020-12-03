using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using IT_Projektas_Backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using IT_Projektas_Backend.Services.AuthService;
using Swashbuckle.AspNetCore.Swagger;
using IT_Projektas_Backend.Responses;
using IT_Projektas_Backend.RequestModels;
using System.Net;
using IT_Projektas_Backend.RequestModels.AuthRequestModels;

namespace IT_Projektas_Backend.Controllers
{
    public class AuthController : ControllerBase
    {
        private readonly it_projektasContext _context;
        private readonly IAuthService _authService;

        public AuthController(it_projektasContext context, IAuthService authService)
        {
            _context = context;
            _authService = authService;
        }

        [HttpPost("api/[controller]/login")]
        public async Task<IActionResult> Login([FromBody]AuthLoginRequest request)
        {
            var profilis = _authService.BuildLoginRequest(request);
            var isUserExists = await _context.Profiliai.AnyAsync(x => x.Pastas.Equals(profilis.Pastas));
            if (!isUserExists)
            {
                return NotFound("Paskyra neegzistuoja");
            }
            var hashedPassword = _authService.HashedPassword(request.Password);
            var isPasswordExists = await _context.Profiliai.AnyAsync(x => x.Password.Equals(hashedPassword));
            if (!isPasswordExists)
            {
                return NotFound("Blogas slaptažodis");
            }
            var user = await _context.Profiliai.Where(x => x.Pastas.Equals(profilis.Pastas)).FirstOrDefaultAsync();
            var passwordExists = await _context.Profiliai.Where(x => x.Password.Equals(hashedPassword)).FirstOrDefaultAsync();

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = await _authService.TokenGenerator(user, tokenHandler);
            return Ok(new AuthLoginResponse { ID = user.Id, Name = user.Vardas, Token = tokenHandler.WriteToken(token) });
        }

        [HttpPost("api/[controller]/registerWorker")]
        public async Task<IActionResult> RegisterWorker([FromBody]AuthRegisterWorkerRequest request)
        {
            var user = _authService.BuildRegisterWorkerProfileRequest(request);

            if (_authService.UserExistsEmail(user.Pastas))
            {
                return BadRequest("Toks vartotojas su tokiu pat el. paštu jau egzistuoja");
            }

            user.Password = _authService.HashedPassword(user.Password);

            // add new user and save him
            await _context.Profiliai.AddAsync(user);
            await _context.SaveChangesAsync();
            // add new worker data
            var workerInfo = await _authService.BuildRegisterWorkerRequest(request);
            await _context.Darbuotojai.AddAsync(workerInfo);
            await _context.SaveChangesAsync();

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = await _authService.TokenGenerator(user, tokenHandler);

            return Ok(new AuthRegisterResponse { ID = user.Id, Name = user.Vardas, Token = tokenHandler.WriteToken(token) });


        }

        [HttpPost("api/[controller]/registerUser")]
        public async Task<IActionResult> RegisterUser([FromBody]AuthRegisterUserRequest request)
        {
            var user = _authService.BuildRegisterUserRequest(request);
            if (_authService.UserExistsEmail(user.Pastas))
            {
                return BadRequest("Toks vartotojas su tokiu pat el. paštu jau egzistuoja");
            }

            user.Password = _authService.HashedPassword(user.Password);

            await _context.Profiliai.AddAsync(user);
            await _context.SaveChangesAsync();
            var clientInfo = await _authService.BuildUserClientProfileRequest(request.Pastas);
            await _context.Klientai.AddAsync(clientInfo);
            await _context.SaveChangesAsync();

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = await _authService.TokenGenerator(user, tokenHandler);

            return Ok(new AuthRegisterResponse { ID = user.Id, Name = user.Vardas, Token = tokenHandler.WriteToken(token) });
        }

        [HttpPost("api/[controller]/changeEmail")]
        public async Task<IActionResult> ChangeEmail([FromBody] AuthChangeEmailRequest req)
        {
            if (req.email == null || req.userId == null)
            {
                return BadRequest();
            }
            var record = await _context.Profiliai.SingleOrDefaultAsync(e => e.Id == int.Parse(req.userId));
            if (record == null)
            {
                return BadRequest("Klaida, toks profilis neegzistuoja");
            }
            record.Pastas = req.email;
            await _context.SaveChangesAsync();

            return Ok(new { message = "Naujas pašto adresas sėkmingai išsaugotas." });


        }
        [HttpPost("api/[controller]/changeAddress")]
        public async Task<IActionResult> ChangeAddress([FromBody] AuthChangeAddressRequest req)
        {
            if (req.address == null || req.userId == null)
            {
                return BadRequest();
            }
            var record = await _context.Profiliai.SingleOrDefaultAsync(e => e.Id == int.Parse(req.userId));
            if (record == null)
            {
                return BadRequest("Klaida, toks profilis neegzistuoja");
            }
            record.Adresas = req.address;
            await _context.SaveChangesAsync();

            return Ok(new { message = "Naujas adresas sėkmingai išsaugotas." });


        }

        [HttpPost("api/[controller]/changePhoneNumber")]
        public async Task<IActionResult> ChangePhoneNumber([FromBody] AuthChangePhoneNumberRequest req)
        {
            if (req.phoneNumber == null || req.userId == null)
            {
                return BadRequest();
            }
            var record = await _context.Profiliai.SingleOrDefaultAsync(e => e.Id == int.Parse(req.userId));
            if (record == null)
            {
                return BadRequest("Klaida, toks profilis neegzistuoja");
            }
            record.TelefonoNr = req.phoneNumber;
            await _context.SaveChangesAsync();

            return Ok(new { message= "Naujas telefono numeris sėkmingai išsaugotas." });
        }

        [HttpGet("api/[controller]/generateNewToken/{id}")]
        public async Task<IActionResult> GenerateNewToken(string id)
        {
            if (id == null)
            {
                return BadRequest("Serverio klaida.");
            }
            var tokenHandler = new JwtSecurityTokenHandler();
            var user = await _context.Profiliai.SingleOrDefaultAsync(e => e.Id == int.Parse(id));

            var newToken = await _authService.TokenGenerator(user, tokenHandler);

            return Ok(new { token = tokenHandler.WriteToken(newToken)  });
        }

        [HttpDelete("api/[controller]/deleteUser/{id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var user = await _context.Profiliai.SingleOrDefaultAsync(e => e.Id == int.Parse(id));

            if (user == null)
            {
                return BadRequest();
            }

            _context.Profiliai.Remove(user);
            await _context.SaveChangesAsync();

            return Ok(new { message="Paskyra pašalinta sėkmingai." });
        }

    }
}
