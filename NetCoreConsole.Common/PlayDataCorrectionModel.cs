using System;

namespace NetCoreConsole.Common
{
    public class BetSlipDataCorrectionModel
    {
        public int Id { get; set; }

        public int MemberId { get; set; }

        public Guid TransactionId { get; set; }

        public decimal Amount { get; set; }

        public int RetailerId { get; set; }

        public object ClientIp { get; set; }
        
        public string Barcode { get; set; }
    }
}