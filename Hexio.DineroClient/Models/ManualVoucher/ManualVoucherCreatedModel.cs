using System;
using System.Collections.Generic;

namespace Hexio.DineroClient.Models.ManualVoucher
{
    public class ManualVoucherCreatedModel
    {
        
        public object VoucherNumber { get; set; }
        public DateTimeOffset VoucherDate { get; set; }
        public long TotalInclVat { get; set; }
        public long TotalExclVat { get; set; }
        public string FileGuid { get; set; }
        public Guid Guid { get; set; }
        public string Status { get; set; }
        public IList<ManualVoucherLineCreatedModel> Lines { get; set; }
        public string Timestamp { get; set; }
        public string ExternalReference { get; set; }
    }
}