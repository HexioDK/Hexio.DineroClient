namespace Hexio.DineroClient.Models.ManualVoucher
{
    public class CreateManualVoucherLineModel
    {
        public string Description { get; set; }
        public long AccountNumber { get; set; }
        public long? BalancingAccountNumber { get; set; } = null;
        public decimal Amount { get; set; }
        public string AccountVatCode { get; set; }
        public string BalancingAccountVatCode { get; set; }
    }
}