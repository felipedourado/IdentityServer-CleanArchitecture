using System.Threading.Tasks;
using SquadPremium.Application.Cities.Commands.Create;
using SquadPremium.Application.Cities.Commands.Delete;
using SquadPremium.Application.Common.Exceptions;
using SquadPremium.Domain.Entities;
using FluentAssertions;
using NUnit.Framework;
using static SquadPremium.Application.IntegrationTests.Testing;

namespace SquadPremium.Application.IntegrationTests.Cities.Commands
{
    public class DeleteCityTests : TestBase
    {
        [Test]
        public void ShouldRequireValidCityId()
        {
            var command = new DeleteCityCommand { Id = 99 };

            FluentActions.Invoking(() =>
                SendAsync(command)).Should().Throw<NotFoundException>();
        }

        [Test]
        public async Task ShouldDeleteCity()
        {
            var city = await SendAsync(new CreateCityCommand
            {
                Name = "Kayseri"
            });

            await SendAsync(new DeleteCityCommand
            {
                Id = city.Data.Id
            });

            var list = await FindAsync<City>(city.Data.Id);

            list.Should().BeNull();
        }
    }
}
