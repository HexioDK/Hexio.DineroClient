using System;
using System.Collections.Generic;

namespace Hexio.DineroClient.Models.Invoices
{
    public class InvoiceCollectionReadModel : IReadModel
    {
        public long? Number { get; set; }
        public string Guid { get; set; }
        public string ExternalReference { get; set; }
        public string Date { get; set; }
        public string PaymentDate { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public string Type { get; set; }
        public string ContactName { get; set; }
        public Guid? ContactGuid { get; set; }
        public long? TotalInclVat { get; set; }
        public long? TotalExclVat { get; set; }
        public long? TotalInclVatInDkk { get; set; }
        public long? TotalExclVatInDkk { get; set; }
        public string MailOutStatus { get; set; }
        public string LatestMailOutType { get; set; }
        public string Currency { get; set; }
        
        public IList<string> FieldsToFilter { get; } = new List<string>
        {
            "ExternalReference",
            "ExternalReference",
            "Description",
        };

        public IList<string> GetDefaultFields()
        {
            return new List<string>
            {
                "Guid",
                "ContactName",
                "Date",
                "Description"
            };
        }

        public bool HasChangesSince()
        {
            return true;
        }
    }

}