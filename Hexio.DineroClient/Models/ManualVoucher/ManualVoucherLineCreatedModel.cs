namespace Hexio.DineroClient.Models.ManualVoucher
{
    public class ManualVoucherLineCreatedModel
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