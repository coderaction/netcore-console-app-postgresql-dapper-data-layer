using System.Collections.Generic;
using System.Threading.Tasks;
using NetCoreConsole.Common;

namespace NetCoreConsole.Service.Core
{
    public interface IPlayService
    {
        List<PlayDataCorrectionModel> GetIncorrectPaidAtRetailerStatusBetSlips();
        Task<List<PlayModel>> GetData(string date);
    }
}