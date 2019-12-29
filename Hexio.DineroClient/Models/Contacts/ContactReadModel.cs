using System;
using System.Collections.Generic;

namespace Hexio.DineroClient.Models.Contacts
{
    public class ContactReadModel : CreateContactModel, IReadModel
    {
        public Guid ContactGuid { get; set; }
        public bool IsDebitor { get; set; }
        public bool IsCreditor { get; set; }

        public IList<string> FieldsToFilter { get; } = new List<string>
        {
            "Name",
            "Email",
            "ExternalReference",
            "VatNumber",
            "EanNumber",
            "IsPerson",
        };

        public IList<string> GetDefaultFields()
        {
            return new List<string>
            {
                "Name",
                "ContactGuid"
            };
        }
    }
}