using IT_Projektas_Backend.Models;
using IT_Projektas_Backend.RequestModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace IT_Projektas_Backend.Services.AuthService
{
    public class AuthService : IAuthService
    {
        private readonly it_projektasContext _context;

        public AuthService(it_projektasContext context)
        {
            _context = context;
        }


        public Profiliai BuildLoginRequest(AuthLoginRequest request)
        {
            var profilis = new Profiliai
            {
                Password = request.Password,
                Pastas = request.Pastas,
            };

            return profilis;
        }
        public async Task<Klientai> BuildUserClientProfileRequest(string userEmail)
        {
            var klientoFk = await _context.Profiliai.Where(profilis => profilis.Pastas == userEmail).FirstOrDefaultAsync();
            var klientas = new Klientai
            {
                FkProfiliaiid = klientoFk.Id,
                GyvunuKiekis = 0
            };

            return klientas;
        }
        public async Task<Darbuotojai> BuildRegisterWorkerRequest(AuthRegisterWorkerRequest request)
        {
            var darbuotojoFk = await _context.Profiliai.Where(profilis => profilis.Pastas == request.Pastas).FirstOrDefaultAsync();

            var darbuotojas = new Darbuotojai
            {
                FkProfiliaiid = darbuotojoFk.Id,
                IsAdmin = request.IsAdmin,
                Pozicija = request.Pozicija
            };

            return darbuotojas;
        }
        public Profiliai BuildRegisterWorkerProfileRequest(AuthRegisterWorkerRequest request)
        {
            var profilis = new Profiliai
            {
                Adresas = request.Adresas,
                AsmensKodas = request.AsmensKodas,
                Password = request.Password,
                Pastas = request.Pastas,
                Pavarde = request.Pavarde,
                TelefonoNr = request.TelefonoNr,
                Username = request.Username,
                Vardas = request.Vardas
            };

            return profilis;
        }
        public Profiliai BuildRegisterUserRequest(AuthRegisterUserRequest request)
        {
            var profilis = new Profiliai
            {
                Adresas = request.Adresas,
                AsmensKodas = request.AsmensKodas,
                Password = request.Password,
                Pastas = request.Pastas,
                Pavarde = request.Pavarde,
                TelefonoNr = request.TelefonoNr,
                Username = request.Username,
                Vardas = request.Vardas
            };

            return profilis;
        }

        public async Task<SecurityToken> TokenGenerator(Profiliai user, JwtSecurityTokenHandler tokenHandler)
        {
            var databaseId = _context.Profiliai.Where(x => x.Pastas == user.Pastas).Single();

            var jwtSettings = new JwtSettings();
            var key = Encoding.ASCII.GetBytes(jwtSettings.secretKey);
            var level = await GetLevelAsync(user);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("id", databaseId.Id.ToString()),
                    new Claim("name", user.Vardas),
                    new Claim("surname", user.Pavarde),
                    new Claim("username", user.Username),
                    new Claim("email", user.Pastas),
                    new Claim("level", level)
                }),
                SigningCredentials =
                    new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return token;
        }
        public  string HashedPassword(string password)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] bytes = md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(password));
            string hashedPassword = "";
            for (int i = 0; i < bytes.Length; i++)
            {
                hashedPassword += bytes[i].ToString("x2");
            }

            return hashedPassword;
        }
        public bool UserExistsEmail(string email)
        {
            return  _context.Profiliai.Any(e => e.Pastas == email);
        }

        private async Task<string> GetLevelAsync(Profiliai user)
        {
            var isWorker = _context.Darbuotojai.Any(darbuotojas => user.Id == darbuotojas.FkProfiliaiid);
            string level = "1";

            if (isWorker)
            {
                var Worker = await _context.Darbuotojai.Where(darbuotojas =>  user.Id == darbuotojas.FkProfiliaiid).FirstAsync();
                if (Worker.IsAdmin == true)
                {
                    level = "3";
                }
                if (Worker.IsAdmin == false)
                {
                    level = "2";
                }
            }

            return level;
        }


    }
}
