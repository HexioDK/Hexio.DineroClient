namespace Hexio.DineroClient.Models.PurchaseVouchers
{
    public class PurchaseVoucherLineReadModel
    {
        public string Description { get; set; }
        public string VatCode { get; set; }
        public long AccountNumber { get; set; }
        public decimal AmountExclVatValue { get; set; }
        public decimal AmountInclVatValue { get; set; }
        public decimal VatAmountValue { get; set; }
    }
}