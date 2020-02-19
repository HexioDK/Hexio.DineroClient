using System;
using System.Collections.Generic;

namespace Hexio.DineroClient.Models.PurchaseVouchers
{
    public class CreatePurchaseVoucherModel
    {
        public List<CreatePurchaseVoucherLineModel> Lines { get; set; }
        public string VoucherDate { get; set; } // Format YYYY-MM-DD
        public long DepositAccountNumber { get; set; }
        public string RegionKey { get; set; }
        public string FileGuid { get; set; }
        public Guid? ContactGuid { get; set; }
        public string PaymentDate { get; set; } // Format YYYY-MM-DD
        public string PurchaseType { get; set; }
        public string ExternalReference { get; set; }
    }
}