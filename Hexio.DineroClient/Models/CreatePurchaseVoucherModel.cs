using System;
using System.Collections.Generic;

namespace Hexio.DineroClient.Models
{
    public class CreatePurchaseVoucherModel
    {
        public List<CreatePurchaseVoucherModelLine> Lines { get; set; }
        public string VoucherDate { get; set; } // Format YYYY-MM-DD
        public long DepositAccountNumber { get; set; }
        public string RegionKey { get; set; }
        public string FileGuid { get; set; }
        public Guid ContactGuid { get; set; }
        public string PaymentDate { get; set; } // Format YYYY-MM-DD
        public string PurchaseType { get; set; }
        public string ExternalReference { get; set; }
    }

    public class CreatePurchaseVoucherModelLine
    {
        public long AccountNumber { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public string VatCode { get; set; }
    }
}