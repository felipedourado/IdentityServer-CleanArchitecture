using System.Threading.Tasks;
using SquadPremium.Application.Cities.Queries.GetCities;
using SquadPremium.Domain.Entities;
using FluentAssertions;
using NUnit.Framework;
using static SquadPremium.Application.IntegrationTests.Testing;

namespace SquadPremium.Application.IntegrationTests.Cities.Queries
{
    public class GetAllCitiesTests : TestBase
    {
        [Test]
        public async Task ShouldReturnAllCities()
        {
            await AddAsync(new City
            {
                Name = "Manisa",
            });

            var query = new GetAllCitiesQuery();

            var result = await SendAsync(query);

            result.Should().NotBeNull();
            result.Succeeded.Should().BeTrue();
            result.Data.Count.Should().BeGreaterThan(0);
        }
    }
}