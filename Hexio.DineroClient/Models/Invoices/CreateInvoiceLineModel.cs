using System;

namespace Hexio.DineroClient.Models.Invoices
{
    public class CreateInvoiceLineModel
    {
        public Guid? ProductGuid { get; set; }
        public string Description { get; set; }
        public string Comments { get; set; }
        public decimal BaseAmountValue { get; set; }
        public string AccountNumber { get; set; } = "1000";
        public string Unit { get; set; } = "month";
        public decimal Quantity { get; set; }
        public decimal Discount { get; set; }
    }
}