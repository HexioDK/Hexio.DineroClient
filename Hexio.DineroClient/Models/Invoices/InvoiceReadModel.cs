using System;
using System.Collections.Generic;

namespace Hexio.DineroClient.Models.Invoices
{
    public class InvoiceReadModel
    {
        public string PaymentDate { get; set; }
        public string PaymentStatus { get; set; }
        public long? PaymentConditionNumberOfDays { get; set; }
        public string PaymentConditionType { get; set; }
        public string FikCode { get; set; }
        public long? DepositAccountNumber { get; set; }
        public string MailOutStatus { get; set; }
        public string LatestMailOutType { get; set; }
        public string Status { get; set; }
        public Guid ContactGuid { get; set; }
        public Guid Guid { get; set; }
        public string TimeStamp { get; set; }
        public long? Number { get; set; }
        public string ContactName { get; set; }
        public bool? ShowLinesInclVat { get; set; }
        public long? TotalExclVat { get; set; }
        public long? TotalVatableAmount { get; set; }
        public long? TotalInclVat { get; set; }
        public long? TotalNonVatableAmount { get; set; }
        public long? TotalVat { get; set; }
        public List<TotalLine> TotalLines { get; set; }
        public string InvoiceTemplateId { get; set; }
        public string Currency { get; set; }
        public string Language { get; set; }
        public string ExternalReference { get; set; }
        public string Description { get; set; }
        public string Comment { get; set; }
        public string Date { get; set; }
        public List<ProductLine> ProductLines { get; set; }
        public string Address { get; set; }
    }

    public class ProductLine
    {
        public string AccountName { get; set; }
        public long? BaseAmountValue { get; set; }
        public long? BaseAmountValueInclVat { get; set; }
        public long? TotalAmount { get; set; }
        public long? TotalAmountInclVat { get; set; }
        public string ProductGuid { get; set; }
        public string Description { get; set; }
        public string Comments { get; set; }
        public long? Quantity { get; set; }
        public long? AccountNumber { get; set; }
        public string Unit { get; set; }
        public long? Discount { get; set; }
        public string LineType { get; set; }
    }

    public class TotalLine
    {
        public string Type { get; set; }
        public long? TotalAmount { get; set; }
        public long? Position { get; set; }
        public string Label { get; set; }
    }
}