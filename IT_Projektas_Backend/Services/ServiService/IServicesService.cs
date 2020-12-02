using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IT_Projektas_Backend.Models;
using IT_Projektas_Backend.Responses.ServResponses;
using IT_Projektas_Backend.RequestModels.ServiRequestModels;

namespace IT_Projektas_Backend.Services.ServiService
{
    public interface IServicesService
    {
        Task<List<ServicesResponses>> BuildServicesGetRequest();
        Paslaugos BuildServicesAddRequest(ServiAddRequest request);
    }
}
