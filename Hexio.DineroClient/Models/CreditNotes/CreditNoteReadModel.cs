using System;
using System.Collections.Generic;
using Hexio.DineroClient.Models.Invoices;

namespace Hexio.DineroClient.Models.CreditNotes
{
    public class CreditNoteReadModel : IReadModel
    {
        public Guid Guid { get; set; }
        public Guid? CreditNoteFor { get; set; }
        public string Status { get; set; }
        public Guid ContactGuid { get; set; }
        public string TimeStamp { get; set; }
        public long? Number { get; set; }
        public string ContactName { get; set; }
        public decimal? TotalExclVat { get; set; }
        public decimal? TotalVatableAmount { get; set; }
        public decimal? TotalInclVat { get; set; }
        public decimal? TotalNonVatableAmount { get; set; }
        public decimal? TotalVat { get; set; }
        public string ExternalReference { get; set; }
        public string Description { get; set; }
        public string Comment { get; set; }
        public DateTime Date { get; set; }
        public List<ProductLine> ProductLines { get; set; }
        public string Address { get; set; }
        public IList<string> FieldsToFilter { get; } = new List<string>
        {
            "ContactGuid",
            "Description",
            "ExternalReference"
        };

        public IList<string> GetDefaultFields()
        {
            return new List<string>
            {
                "Guid",
                "ContactName",
                "Date",
                "Description",
                "Type"
            };
        }

        public bool HasChangesSince()
        {
            return true;
        }
    }
}