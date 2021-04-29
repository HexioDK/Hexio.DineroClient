using System;
using System.Collections.Generic;

namespace Hexio.DineroClient.Models.Invoices
{
    public class CreateInvoiceModel
    {
        public int? PaymentConditionNumberOfDays { get; set; } = null;
        public string PaymentConditionType { get; set; } = null;
        public string Comment { get; set; }
        public string Date { get; set; }
        public Guid ContactGuid { get; set; }
        public Guid? InvoiceTemplateId { get; set; }
        public string ExternalReference { get; set; }
        public string Timestamp { get; set; }
        public ICollection<CreateInvoiceLineModel> ProductLines { get; set; }
    }
}