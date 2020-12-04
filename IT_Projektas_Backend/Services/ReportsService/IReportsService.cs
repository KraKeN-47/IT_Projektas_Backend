using IT_Projektas_Backend.Responses.ReportsResponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IT_Projektas_Backend.Services.ReportsService
{
    public interface IReportsService
    {

        Task<List<PositionsResponse>> PositionsReport();
        Task<PersonalResponse> PersonalReport(int profileID);

        Task<List<WorkerResponseForGet>> GetWorkers();
    }
}
