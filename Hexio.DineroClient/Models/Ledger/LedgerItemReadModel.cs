using System;
using System.Collections.Generic;

namespace Hexio.DineroClient.Models.Ledger
{
    public class LedgerItemModel
    {
        public Guid? Id { get; set; }
        public string Version { get; set; }
        public int? VoucherNumber { get; set; }
        public string VoucherDate { get; set; }
        public string FileGuid { get; set; }
        public IList<LedgerItemLineModel> Lines { get; set; } = new List<LedgerItemLineModel>();
    }

    public class LedgerItemLineModel
    {
        public Guid? Id { get; set; }
        public string Description { get; set; }
        public double Amount { get; set; }
        public int? AccountNumber { get; set; }
        public string AccountVatCode { get; set; }
        public int? BalancingAccountNumber { get; set; }
        public string BalancingAccountVatCode { get; set; }
        public Guid? IsPaymentForVoucherId { get; set; }
    }
}