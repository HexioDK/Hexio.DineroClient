namespace Hexio.DineroClient.Models
{
    public class CreateEntryAccountModel
    {
        public int Number { get; set; }
        public string Name { get; set; }
        public string VatCode { get; set; } = "I25";
    }
}