using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using NetCoreConsole.Common;
using NetCoreConsole.Core;
using NetCoreConsole.Service.Core;

namespace NetCoreConsole.Service
{
    public class PlayService: IPlayService
    {
        private readonly IConfiguration _configuration;
        private readonly IPlayRepository _playRepository;

        public PlayService(IConfiguration configuration, IPlayRepository playRepository)
        {
            _configuration = configuration;
            _playRepository = playRepository;
        }
        
        public List<PlayDataCorrectionModel> GetIncorrectPaidAtRetailerStatusBetSlips()
        {
            return _playRepository.GetPlayStatus();
        }
        
        public async Task<List<PlayModel>> GetData(string date)
        {
            return await _playRepository.GetPlayAgreement(date);
        }
    }
}