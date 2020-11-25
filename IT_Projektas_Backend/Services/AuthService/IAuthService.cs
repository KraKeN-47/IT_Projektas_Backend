using IT_Projektas_Backend.Models;
using IT_Projektas_Backend.RequestModels;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace IT_Projektas_Backend.Services.AuthService
{
    public interface IAuthService
    {
        Task<Klientai> BuildUserClientProfileRequest(string userEmail);
        Profiliai BuildLoginRequest(AuthLoginRequest request);
        Task<Darbuotojai> BuildRegisterWorkerRequest(AuthRegisterWorkerRequest request);
        Profiliai BuildRegisterWorkerProfileRequest(AuthRegisterWorkerRequest request);
        Profiliai BuildRegisterUserRequest(AuthRegisterUserRequest request);
        Task<SecurityToken> TokenGenerator(Profiliai user, JwtSecurityTokenHandler tokenHandler);
        string HashedPassword(string password);
        bool UserExistsEmail(string email);

    }
}
