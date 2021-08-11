using System.Collections.Generic;
using System.Threading.Tasks;
using SquadPremium.Application.Cities.Commands.Create;
using SquadPremium.Application.Districts.Commands.Create;
using SquadPremium.Application.Villages.Queries.GetVillagesWithPagination;
using SquadPremium.Domain.Entities;
using FluentAssertions;
using NUnit.Framework;
using static SquadPremium.Application.IntegrationTests.Testing;

namespace SquadPremium.Application.IntegrationTests.Villages.Queries
{
    public class GetAllVillagesWithPaginationTests : TestBase
    {
        [Test]
        public async Task ShouldReturnAllCities()
        {
            var city = await SendAsync(new CreateCityCommand
            {
                Name = "Muğla"
            });

            var district = await SendAsync(new CreateDistrictCommand
            {
                Name = "Bodrum",
                CityId = city.Data.Id
            });

            List<string> villages = new List<string> { "Çömlekçi", "Müsgebi", "Karakaya", "Etrim", "Sandima", "Akyarlar", "Gündoğan" };

            foreach (var name in villages)
            {
                await AddAsync(new Village
                {
                    Name = name,
                    DistrictId = district.Data.Id
                });
            }

            var query = new GetAllVillagesWithPaginationQuery
            {
                DistrictId = district.Data.Id,
                PageNumber = 1,
                PageSize = 3
            };

            var result = await SendAsync(query);

            result.Should().NotBeNull();
            result.Succeeded.Should().BeTrue();
            result.Data.Items.Count.Should().Be(3);
            result.Data.TotalCount.Should().Be(7);
        }
    }
}
