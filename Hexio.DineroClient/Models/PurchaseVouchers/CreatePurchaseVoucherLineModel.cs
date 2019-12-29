namespace Hexio.DineroClient.Models.PurchaseVouchers
{
    public class CreatePurchaseVoucherLineModel
    {
        public long AccountNumber { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public string VatCode { get; set; }
    }
}