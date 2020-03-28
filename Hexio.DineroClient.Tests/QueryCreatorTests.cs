using System;
using FluentAssertions;
using Hexio.DineroClient.Models.Contacts;
using Xunit;

namespace Hexio.DineroClient.Tests
{
    public class QueryCreatorTests
    {
        [Fact]
        public void Test_QueryCreatorFormatIsCorrect()
        {
            var queryCreator = new QueryCreator<ContactReadModel>();

            var date = DateTimeOffset.UtcNow;

            queryCreator.ChangeSince(date);
            
            var dateString = date.ToString("yyyy-MM-ddTHH:mm:ssZ");
            
            
            queryCreator.ToString().Should().Be($"changesSince={dateString}&page=0&pageSize=100");

            queryCreator.Where(x => x.Name, QueryOperator.Eq, "Morten");
            
            queryCreator.ToString().Should().Be($"queryFilter=Name+eq+'Morten'&changesSince={dateString}&page=0&pageSize=100");
            
            queryCreator.Include(x => x.Name);
            
            queryCreator.ToString().Should().Be($"fields=Name&queryFilter=Name+eq+'Morten'&changesSince={dateString}&page=0&pageSize=100");
        }
    }
}