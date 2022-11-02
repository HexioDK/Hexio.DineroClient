using System;

namespace Hexio.DineroClient.Models.Sales
{
    public class DefaultInvoiceSettings
    {
        public bool LinesInclVat { get; set; }
        public string FikCode { get; set; }
        public bool UseFikCode { get; set; }
        public int DefaultAccountNumber { get; set; }
        public Guid? InvoiceTemplateId { get; set; }
        public bool AddVoucherAsPdfAttachment { get; set; }
        public double ReminderFee { get; set; }
        public double ReminderInterestRate { get; set; }
    }
}