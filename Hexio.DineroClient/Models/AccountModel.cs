namespace Hexio.DineroClient.Models
{
    public class AccountModel
    {
        public int AccountNumber { get; set; }
        public string Name { get; set; }
        public string VatCode { get; set; }
        public string Category { get; set; }
        public bool IsHidden { get; set; }
        public bool IsDefaultSalesAccount { get; set; }
    }
}