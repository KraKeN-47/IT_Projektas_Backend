using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IT_Projektas_Backend.Models;
using IT_Projektas_Backend.Responses.ServRegResponses;
using IT_Projektas_Backend.RequestModels.ServiRegRequestModels;

namespace IT_Projektas_Backend.Services.ServiRegistrationService
{
    public interface IServiRegService
    {
        Task<List<ServicesRegistrationResponses>> BuildServicesGetRegRequest(ServiRegGetRequest req);
        PaslaugosRezervacija BuildServicesAddRegRequest(ServiRegAddRequest req);
    }
}
