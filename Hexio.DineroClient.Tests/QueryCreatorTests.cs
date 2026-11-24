using System;
using System.Globalization;
using FluentAssertions;
using Hexio.DineroClient.Models.Contacts;
using Xunit;

namespace Hexio.DineroClient.Tests
{
    public class QueryCreatorTests
    {
        [Fact]
        public void Test_ChangesSinceIgnoresTheCurrentCulture()
        {
            var culture = CultureInfo.CurrentCulture;
            CultureInfo.CurrentCulture = new CultureInfo("da-DK");

            try
            {
                var query = new QueryCreator<ContactReadModel>()
                    .ChangeSince(new DateTimeOffset(2026, 11, 24, 8, 28, 58, TimeSpan.Zero));

                query.ToString().Should().Contain("changesSince=2026-11-24T08:28:58Z");
            }
            finally
            {
                CultureInfo.CurrentCulture = culture;
            }
        }

        [Fact]
        public void Test_QueryCreatorFormatIsCorrect()
        {
            var queryCreator = new QueryCreator<ContactReadModel>();

            // A non-UTC time, so the test shows it is sent as UTC.
            var date = new DateTimeOffset(2026, 11, 24, 9, 28, 58, TimeSpan.FromHours(1));

            queryCreator.ChangeSince(date);

            const string dateString = "2026-11-24T08:28:58Z";

            queryCreator.ToString().Should().Be($"fields=Name,ContactGuid&changesSince={dateString}&page=0&pageSize=100");

            queryCreator.Where(x => x.Name, QueryOperator.Eq, "Morten");
            
            queryCreator.ToString().Should().Be($"fields=Name,ContactGuid&queryFilter=Name+eq+'Morten'&changesSince={dateString}&page=0&pageSize=100");
            
            queryCreator.Include(x => x.Name);
            
            queryCreator.ToString().Should().Be($"fields=Name,ContactGuid&queryFilter=Name+eq+'Morten'&changesSince={dateString}&page=0&pageSize=100");
        }
    }
}