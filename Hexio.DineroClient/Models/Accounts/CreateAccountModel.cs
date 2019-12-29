namespace Hexio.DineroClient.Models.Accounts
{
    public class CreateAccountModel
    {
        public int Number { get; set; }
        public string Name { get; set; }
        public string VatCode { get; set; } = "I25";
    }
}