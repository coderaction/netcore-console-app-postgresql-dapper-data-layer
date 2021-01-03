using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Data.PostgreSql;
using Microsoft.Extensions.Configuration;
using NetCoreConsole.Common;
using NetCoreConsole.Core;

namespace NetCoreConsole.PostgreSql
{
    public class PlayRepository:BaseRepository,IPlayRepository
    {
        public PlayRepository(IConfiguration configuration) : base(configuration)
        {
        }
        
        public  List<PlayDataCorrectionModel> GetPlayStatus()
        {
            return WithReadonlyConnection(conn =>
            {
                var result = conn.Query<PlayDataCorrectionModel>(
                    "get_play", commandType: CommandType.StoredProcedure);
                return result.ToList();
            });
        }

        public async Task<List<PlayModel>> GetPlayAgreement(string date)
        {
            return await WithConnection(async conn =>
            {
                var result = await conn.QueryAsync<PlayModel>(
                    "get_play",
                    new
                    {
                        param_start_date = Convert.ToDateTime(date),
                    }, commandType: CommandType.StoredProcedure);

                return result.ToList();
            });
        }
    }
}