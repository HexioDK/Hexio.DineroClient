using System;

namespace Hexio.DineroClient.Models.PurchaseVouchers
{
    public class CreateCreditNoteFromPurchaseVoucerModel
    {
        public TimestampContainer Timestamp { get; set; }
        public string VoucherDate { get; set; }
    }

    public class TimestampContainer
    {
        public string Timestamp { get; set; }
    }
}