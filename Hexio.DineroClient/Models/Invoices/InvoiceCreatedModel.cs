using System;

namespace Hexio.DineroClient.Models.Invoices
{
    public class InvoiceCreatedModel
    {
        public Guid Guid { get; set; }
        public string TimeStamp { get; set; }
    }
}