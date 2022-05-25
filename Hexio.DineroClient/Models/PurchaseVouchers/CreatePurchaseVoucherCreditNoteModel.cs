using System;
using System.Collections.Generic;

namespace Hexio.DineroClient.Models.PurchaseVouchers
{
    public abstract class PurchaseVoucherCreditNoteBaseModel
    {
        public string Date { get; set; } // Format YYYY-MM-DD
        public string FileGuid { get; set; }
        public Guid? ContactGuid { get; set; }
        public string Currency { get; set; } = "DKK";
        public Guid? CreditNoteFor { get; set; }
        public string Timestamp { get; set; }
    }

    public class CreatePurchaseVoucherCreditNoteModel : PurchaseVoucherCreditNoteBaseModel
    {
        public List<CreatePurchaseVoucherLineModel> Lines { get; set; }
    }

    public class PurchaseVoucherCreditNoteReadModel : PurchaseVoucherCreditNoteBaseModel
    {
        public Guid Guid { get; set; }
        public List<PurchaseVoucherLineReadModel> Lines { get; set; }
        public PurchaseVoucherCreditNoteStatus Status { get; set; }
    }

    public enum PurchaseVoucherCreditNoteStatus
    {
        Draft,
        Paid,
        Editing,
        Booked,
        Overdue,
        Overpaid,
    }
}