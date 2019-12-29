using System;
using System.Collections.Generic;

namespace Hexio.DineroClient.Models.Invoices
{
    public class CreateInvoiceModel
    {
        public Guid ContactGuid { get; set; }
        public string ExternalReference { get; set; }
        public ICollection<CreateInvoiceLineModel> ProductLines { get; set; }
    }
}