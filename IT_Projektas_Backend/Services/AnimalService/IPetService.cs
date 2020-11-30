using IT_Projektas_Backend.Models;
using IT_Projektas_Backend.RequestModels.AnimalRequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IT_Projektas_Backend.Services.AnimalService
{
    public interface IPetService
    {
        Gyvunai AddPet(PetRequest pet);
    }
}
