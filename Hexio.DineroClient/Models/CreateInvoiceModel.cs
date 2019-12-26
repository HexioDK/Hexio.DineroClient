using System;
using System.Collections.Generic;

namespace Hexio.DineroClient.Models
{
    public class CreateInvoiceModel
    {
        public Guid ContactGuid { get; set; }
        public string ExternalReference { get; set; }
        public ICollection<CreateInvoiceLineModel> ProductLines { get; set; }
    }

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