using FluentAssertions;
using Hexio.DineroClient.Models.Contacts;
using Newtonsoft.Json;
using Xunit;

namespace Hexio.DineroClient.Tests
{
    public class ContactSerializationTests
    {
        [Fact]
        public void InvoiceMailOutOptionKey_IsSentAsText()
        {
            var json = JsonConvert.SerializeObject(new CreateContactModel { InvoiceMailOutOptionKey = MailoutOption.GLN });

            json.Should().Contain("\"InvoiceMailOutOptionKey\":\"GLN\"");
        }

        [Fact]
        public void InvoiceMailOutOptionKey_IsReadFromText()
        {
            var contact = JsonConvert.DeserializeObject<CreateContactModel>("{\"InvoiceMailOutOptionKey\":\"VAT\"}");

            contact.InvoiceMailOutOptionKey.Should().Be(MailoutOption.VAT);
        }

        [Fact]
        public void InvoiceMailOutOptionKey_IsNullForNone()
        {
            var json = JsonConvert.SerializeObject(new CreateContactModel());

            json.Should().Contain("\"InvoiceMailOutOptionKey\":null");
        }
    }
}
