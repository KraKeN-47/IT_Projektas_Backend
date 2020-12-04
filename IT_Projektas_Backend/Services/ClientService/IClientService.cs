using IT_Projektas_Backend.Models;
using IT_Projektas_Backend.RequestModels.AnimalRequestModels;
using IT_Projektas_Backend.Responses.ClientRsponses;
using IT_Projektas_Backend.Responses.PetResponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IT_Projektas_Backend.Services.ClientService
{
    public interface IClientService
    {
        Task<List<ClientRetrieveResponse>> GetClients();
    }
}
