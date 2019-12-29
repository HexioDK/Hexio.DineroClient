using System;

namespace Hexio.DineroClient.Models.Invoices
{
    public class CreateInvoiceLineModel
    {
        public Guid ProductGuid { get; set; }
        public string Comments { get; set; }
        public decimal BaseAmountValue { get; set; }
        public string AccountNumber { get; set; } = "1000";
        public string Unit { get; set; } = "month";
        public int Quantity { get; set; }
    }
}