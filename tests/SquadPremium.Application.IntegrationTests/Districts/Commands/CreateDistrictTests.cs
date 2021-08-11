using System;
using System.Threading.Tasks;
using SquadPremium.Application.Cities.Commands.Create;
using SquadPremium.Application.Common.Exceptions;
using SquadPremium.Application.Districts.Commands.Create;
using SquadPremium.Domain.Entities;
using FluentAssertions;
using NUnit.Framework;
using static SquadPremium.Application.IntegrationTests.Testing;

namespace SquadPremium.Application.IntegrationTests.Districts.Commands
{
    public class CreateDistrictTests
    {
        [Test]
        public void ShouldRequireMinimumFields()
        {
            var command = new CreateDistrictCommand();

            FluentActions.Invoking(() =>
                SendAsync(command)).Should().Throw<ValidationException>();

        }

        [Test]
        public async Task ShouldCreateDistrict()
        {
            var city = await SendAsync(new CreateCityCommand
            {
                Name = "Bursa"
            });

            var userId = await RunAsDefaultUserAsync();

            var command = new CreateDistrictCommand
            {
                Name = "Karacabey",
                CityId = city.Data.Id
            };

            var result = await SendAsync(command);

            var list = await FindAsync<District>(result.Data.Id);

            list.Should().NotBeNull();
            list.Name.Should().Be(command.Name);
            list.Creator.Should().Be(userId);
            list.CreateDate.Should().BeCloseTo(DateTime.Now, 10000);
        }
    }
}
