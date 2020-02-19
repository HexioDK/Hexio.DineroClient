namespace Hexio.DineroClient.Models.Products
{
    public class CreateProductModel
    {
        public string ProductNumber { get; set; }
        public string Name { get; set; }
        public decimal? BaseAmountValue { get; set; }
        public decimal? Quantity { get; set; }
        public long AccountNumber { get; set; }
        public string Unit { get; set; }
        public string ExternalReference { get; set; }
        public string Comment { get; set; }
    }
}