using IT_Projektas_Backend.Models;
using IT_Projektas_Backend.RequestModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Org.BouncyCastle.Ocsp;
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

        public async Task<bool> UserExists(int id)
        {
            Klientai kl = await _context.Klientai.Where(x => x.IdKlientai == id).FirstOrDefaultAsync();
            return kl != null;
        }

        public void RemoveUser(int id)
        {
            Klientai user = _context.Klientai.Where(x => x.IdKlientai == id).FirstOrDefault();
            Profiliai profiliai = _context.Klientai.Where(x => x.IdKlientai == id).Select(x => x.FkProfiliai).FirstOrDefault();
            _context.Klientai.Remove(user);
            _context.Profiliai.Remove(profiliai);
            _context.SaveChanges();
        }

        public async Task<Profiliai> UpdateUser(AuthRegisterUserRequest request, int id)
        {
            Profiliai user = await _context.Klientai.Where(x => x.IdKlientai == id).Select(x => x.FkProfiliai).FirstOrDefaultAsync();
            if (request.Adresas != null)
                user.Adresas = request.Adresas;
            if (request.AsmensKodas != null)
                user.AsmensKodas = request.AsmensKodas;
            if (request.Pastas != null)
                user.Pastas = request.Pastas;
            if (request.Pavarde != null)
                user.Pavarde = request.Pavarde;
            if (request.TelefonoNr != null)
                user.TelefonoNr = request.TelefonoNr;
            if (request.Username != null)
                user.Username = request.Username;
            if (request.Vardas != null)
                user.Vardas = request.Vardas;
            _context.Update(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<bool> WorkerExists(int id)
        {
            Darbuotojai worker = await _context.Darbuotojai.Where(x => x.IdDarbuotojai == id).FirstOrDefaultAsync();
            return worker != null;
        }

        public async Task<Profiliai> UpdateWorker(AuthRegisterWorkerRequest request, int id)
        {
            Profiliai user = await _context.Darbuotojai.Where(x => x.IdDarbuotojai == id).Include(x=>x.FkProfiliai).Select(x=>x.FkProfiliai).FirstOrDefaultAsync();
            if (request.Adresas != null)
                user.Adresas = request.Adresas;
            if (request.AsmensKodas != null)
                user.AsmensKodas = request.AsmensKodas;
            if (request.Pastas != null)
                user.Pastas = request.Pastas;
            if (request.Pavarde != null)
                user.Pavarde = request.Pavarde;
            if (request.TelefonoNr != null)
                user.TelefonoNr = request.TelefonoNr;
            if (request.Username != null)
                user.Username = request.Username;
            if (request.Vardas != null)
                user.Vardas = request.Vardas;
            if (request.Pozicija != null)
                user.Darbuotojai.Pozicija = request.Pozicija;
            if (request.IsAdmin != null)
                user.Darbuotojai.IsAdmin = request.IsAdmin;
            _context.Update(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public void RemoveWorker(int id)
        {
            Darbuotojai user = _context.Darbuotojai.Where(x => x.IdDarbuotojai == id).FirstOrDefault();
            Profiliai profiliai = _context.Darbuotojai.Where(x => x.IdDarbuotojai == id).Select(x => x.FkProfiliai).FirstOrDefault();
            _context.Darbuotojai.Remove(user);
            _context.Profiliai.Remove(profiliai);
            _context.SaveChanges();
        }
    }
}
