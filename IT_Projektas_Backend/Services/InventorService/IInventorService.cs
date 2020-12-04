using IT_Projektas_Backend.Models;
using IT_Projektas_Backend.RequestModels.InventorRequestModels;
using IT_Projektas_Backend.Responses.InventorResponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace IT_Projektas_Backend.Services.InventorService
{
    public interface IInventorService
    {
        Task<List<InventorResponse>> GetInventor();
        Inventorius AddInventor(InventorReq inv);
    }
}
