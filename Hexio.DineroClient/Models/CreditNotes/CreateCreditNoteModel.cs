using System;
using System.Collections.Generic;
using Hexio.DineroClient.Models.Invoices;

namespace Hexio.DineroClient.Models.CreditNotes
{
    public class CreateCreditNoteModel
    {
        public Guid CreditNoteFor { get; set; }
        public Guid ContactGuid { get; set; }
        public bool ShowLinesInclVat { get; set; } = false;
        public string Comment { get; set; }
        public string Date { get; set; }
        public string ExternalReference { get; set; }
        public string Description { get; set; }
        public string Currency { get; set; } = "DKK";
        public ICollection<CreateInvoiceLineModel> ProductLines { get; set; }
    }
}