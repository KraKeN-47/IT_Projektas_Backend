using IT_Projektas_Backend.Models;
using IT_Projektas_Backend.RequestModels.AnimalRequestModels;
using IT_Projektas_Backend.Responses.PetResponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IT_Projektas_Backend.Services.AnimalService
{
    public interface IPetService
    {
        Task<List<PetRetrieveResponse>> GetPets();
        Task<List<PetRetrieveResponse>> GetUserPets(int id);
        Gyvunai AddPet(PetRequest pet);
        void RemovePet(int id);
    }
}
