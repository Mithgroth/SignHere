using FluentAssertions;
using SignHere.Database;
using SignHere.Test.Utility;
using System.Collections.Generic;
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

        public static IEnumerable<object[]> FindExtensionsData =>
            new List<object[]>
            {
                new object[]
                {
                    "Bitmap",
                    new List<Extension>()
                    {
                        Extension.BMP,
                        Extension.CAL,
                        Extension.DCX,
                        Extension.DIB,
                        Extension.IMG,
                        Extension.MP,
                        Extension.PAX,
                        Extension.RGB
                    }
                },
            };

        [Theory]
        [MemberData(nameof(FindExtensionsData))]
        public void Calling_FindExtensions_Properly_Should_Return_List_Of_Extensions(string searchText, IEnumerable<Extension> expected)
        {
            // Act
            var actual = Vault.FindExtensions(searchText);

            // Assert
            actual.Should().BeEquivalentTo(expected);
        }
    }
}