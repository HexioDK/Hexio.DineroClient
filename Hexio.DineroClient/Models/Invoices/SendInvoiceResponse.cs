using System.Collections.Generic;

namespace Hexio.DineroClient.Models.Invoices
{
    public class SendInvoiceResponse
    {
        public IList<InvoiceRecipientModel> Recipients { get; set; }
    }

    public class InvoiceRecipientModel
    {
        public string Email { get; set; }
    }
}