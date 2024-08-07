namespace Hexio.DineroClient.Models.Contacts
{
    public class CreateContactModel
    {
        public string ExternalReference { get; set; }
        public string Name { get; set; }
        public string Street { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string CountryKey { get; set; } = "DK";
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Webpage { get; set; }
        public string AttPerson { get; set; }
        public string VatNumber { get; set; }
        public string EanNumber { get; set; }
        public string PaymentConditionType { get; set; }
        public long? PaymentConditionNumberOfDays { get; set; }
        public bool IsPerson { get; set; }
        public bool IsMember { get; set; }
        public string MemberNumber { get; set; }
        public bool UseCvr { get; set; }
        public string CompanyTypeKey { get; set; }
        public MailoutOption? InvoiceMailOutOptionKey { get; set; }
    }

    public enum MailoutOption
    {
        VAT,
        GLN,
        SE,
        P
    }
}
