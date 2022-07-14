namespace Hexio.DineroClient.Models
{
    public class OrganizationReadModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsPro { get; set; }
        public string Email { get; set; }
        public string VatNumber { get; set; }
        public string Phone { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string AttPerson { get; set; }
    }
}