namespace Hexio.DineroClient.Models.Invoices
{
    public class SendInvoiceEmailModel : InvoiceEmailTemplateModel
    {
        public bool CcToSender { get; set; } = false;
    }

    public class InvoiceEmailTemplateModel
    {
        public string Sender { get; set; }
        public string Receiver { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public bool AddVoucherAsPdfAttachment { get; set; }
    }

    public class SendInvoiceWithEanModel
    {
        public string OrderReference { get; set; }
        public string AttPerson { get; set; }
        public string ReceiverEanNumber { get; set; }
    }
}