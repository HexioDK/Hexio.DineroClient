using System;
using System.Collections.Generic;

namespace Hexio.DineroClient.Models
{
    public class PurchaseVoucherModel
    {
        public Guid Guid { get; set; }
        public string Timestamp { get; set; }
        public string Status { get; set; }
        public string FileGuid { get; set; }
        public object VoucherNumber { get; set; }
        public DateTimeOffset VoucherDate { get; set; }
        public DateTimeOffset? PaymentDate { get; set; }
        public string RegionKey { get; set; }
        public string PurchaseType { get; set; }
        public List<PurchaseVoucherModelLine> Lines { get; set; }
        public int? DepositAccountNumber { get; set; }
        public object ContactGuid { get; set; }
        public string ExternalReference { get; set; }

        public BookVoucherModel GetBookModel()
        {
            return new BookVoucherModel
            {
                TimeStamp = Timestamp,
            };
        }
    }

    public class PurchaseVoucherModelLine
    {
        public string Description { get; set; }
        public string VatCode { get; set; }
        public long AccountNumber { get; set; }
        public decimal AmountExclVatValue { get; set; }
        public decimal AmountInclVatValue { get; set; }
        public decimal VatAmountValue { get; set; }
    }

}