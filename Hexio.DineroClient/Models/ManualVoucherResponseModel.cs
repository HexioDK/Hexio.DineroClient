using System;
using System.Collections.Generic;

namespace Hexio.DineroClient.Models
{
    public class ManualVoucherResponseModel
    {
        
        public object VoucherNumber { get; set; }
        public DateTimeOffset VoucherDate { get; set; }
        public long TotalInclVat { get; set; }
        public long TotalExclVat { get; set; }
        public string FileGuid { get; set; }
        public Guid Guid { get; set; }
        public string Status { get; set; }
        public IList<ManualVoucherLineResponseModel> Lines { get; set; }
        public string Timestamp { get; set; }
        public string ExternalReference { get; set; }
    }
    
    public class ManualVoucherLineResponseModel
    {
        public string Description { get; set; }
        public decimal AmountExclVatValue { get; set; }
        public decimal AmountInclVatValue { get; set; }
        public decimal VatAmountValue { get; set; }
        public long AccountNumber { get; set; }
        public long? BalancingAccountNumber { get; set; }
        public string AccountVatCode { get; set; }
        public string BalancingAccountVatCode { get; set; }
    }
}