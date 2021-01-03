using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NetCoreConsole.Common;

namespace NetCoreConsole.Core
{
    public interface IPlayRepository
    {
        List<PlayDataCorrectionModel> GetPlayStatus();
        Task<List<PlayModel>> GetPlayAgreement(string date);
    }

}