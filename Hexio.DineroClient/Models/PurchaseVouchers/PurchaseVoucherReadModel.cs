using System;
using System.Collections.Generic;

namespace Hexio.DineroClient.Models.PurchaseVouchers
{
    public class PurchaseVoucherReadModel
    {
        public Guid Guid { get; set; }
        public string Timestamp { get; set; }
        public string Status { get; set; }
        public string FileGuid { get; set; }
        public int? VoucherNumber { get; set; }
        public DateTimeOffset VoucherDate { get; set; }
        public DateTimeOffset? PaymentDate { get; set; }
        public string RegionKey { get; set; }
        public string PurchaseType { get; set; }
        public List<PurchaseVoucherLineReadModel> Lines { get; set; }
        public int? DepositAccountNumber { get; set; }
        public Guid? ContactGuid { get; set; }
        public string ExternalReference { get; set; }

        public BookVoucherModel GetBookModel()
        {
            return new BookVoucherModel
            {
                TimeStamp = Timestamp,
            };
        }
    }
}