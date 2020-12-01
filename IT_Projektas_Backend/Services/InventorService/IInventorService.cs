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
        
    }
}
