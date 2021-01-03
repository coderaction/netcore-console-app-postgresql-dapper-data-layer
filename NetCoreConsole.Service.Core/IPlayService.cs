using System.Collections.Generic;
using System.Threading.Tasks;
using NetCoreConsole.Common;

namespace NetCoreConsole.Core
{
    public class IPlayService
    {
        Task<List<PlayModel>> GetPlayMember(string date);
    }
}