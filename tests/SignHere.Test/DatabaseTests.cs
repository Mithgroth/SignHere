using FluentAssertions;
using SignHere.Database;
using SignHere.Test.Utility;
using System.Threading.Tasks;
using Xunit;

namespace SignHere.Test
{
    public class DatabaseTests
    {
        [Fact]
        public async Task Vault_Should_Be_Up_To_Date()
        {
            var source = await FileSignaturesNetCrawler.GetSignatures();

            // Assert
            Vault.Bank.Should().BeEquivalentTo(source);
        }
    }
}