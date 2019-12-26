using System;

namespace Hexio.DineroClient.Models
{
    public class ContactModel
    {
        public Guid ContactGuid { get; set; }
        public string Name { get; set; }
        public string ExternalReference { get; set; }
        public string VatNumber { get; set; }
        public bool IsPerson { get; set; } = false;
        public bool UseCvr { get; set; } = true;
        public string CountryKey { get; set; } = "DK";
    }
}
