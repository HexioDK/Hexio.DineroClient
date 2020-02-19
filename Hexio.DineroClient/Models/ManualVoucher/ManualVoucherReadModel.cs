using System;
using System.Collections.Generic;

namespace Hexio.DineroClient.Models.ManualVoucher
{
    public class ManualVoucherReadModel
    {
        public int? VoucherNumber { get; set; }
        public DateTimeOffset VoucherDate { get; set; }
        public decimal TotalInclVat { get; set; }
        public decimal TotalExclVat { get; set; }
        public string FileGuid { get; set; }
        public Guid Guid { get; set; }
        public string Status { get; set; }
        public IList<ManualVoucherLineReadModel> Lines { get; set; }
        public string Timestamp { get; set; }
        public string ExternalReference { get; set; }
    }
}