using System.Collections.Generic;

namespace Hexio.DineroClient.Models.ManualVoucher
{
    public class CreateManualVoucherModel
    {
        public string VoucherDate { get; set; } // Format YYYY-MM-DD
        public IList<CreateManualVoucherLineModel> Lines { get; set; }
        public string FileGuid { get; set; }
        public string ExternalReference { get; set; }
    }
}