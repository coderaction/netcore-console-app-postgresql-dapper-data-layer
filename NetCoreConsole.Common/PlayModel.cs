using System;

namespace NetCoreConsole.Common
{
    public class PlayModel
    {
        public int PlayId { get; set; }

        public int SocketNo { get; set; }

        public string KeySocket { get; set; }
        
        public string PlayState { get; set; }

        public DateTime TransactionDate { get; set; }

        public int PlaySlipNo { get; set; }

        public Guid ExternalTaKey { get; set; }
    }
}