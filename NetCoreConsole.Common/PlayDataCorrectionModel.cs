using System;

namespace NetCoreConsole.Common
{
    public class PlayDataCorrectionModel
    {
        public int Id { get; set; }

        public int MemberId { get; set; }

        public Guid TransactionId { get; set; }

        public decimal Amount { get; set; }

        public object ClientIp { get; set; }
    }
}