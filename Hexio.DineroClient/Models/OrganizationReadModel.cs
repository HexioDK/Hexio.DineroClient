namespace Hexio.DineroClient.Models
{
    public class OrganizationReadModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsPro { get; set; }
        public string Email { get; set; }
        public string VatNumber { get; set; }
    }
}