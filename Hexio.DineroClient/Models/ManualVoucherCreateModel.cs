using System.Collections.Generic;

namespace Hexio.DineroClient.Models
{
    public class ManualVoucherCreateModel
    {
        public string VoucherDate { get; set; } // Format YYYY-MM-DD
        public IList<ManualVoucherLine> Lines { get; set; }
        public string FileGuid { get; set; }
        public string ExternalReference { get; set; }
    }

    public class ManualVoucherLine
    {
        public string Description { get; set; }
        public long AccountNumber { get; set; }
        public long? BalancingAccountNumber { get; set; } = null;
        public decimal Amount { get; set; }
        public string AccountVatCode { get; set; }
        public string BalancingAccountVatCode { get; set; }
    }
}