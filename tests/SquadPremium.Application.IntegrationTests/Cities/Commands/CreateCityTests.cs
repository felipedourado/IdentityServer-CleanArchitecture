using System;
using System.Threading.Tasks;
using SquadPremium.Application.Common.Exceptions;
using FluentAssertions;
using NUnit.Framework;
using static SquadPremium.Application.IntegrationTests.Testing;

namespace SquadPremium.Application.IntegrationTests.Cities.Commands
{
    public class CreateCityTests : TestBase
    {
        [Test]
        public void ShouldRequireMinimumFields()
        {
            // var command = new CreateCityCommand();
            //
            // FluentActions.Invoking(() =>
            //     SendAsync(command)).Should().Throw<ValidationException>();

        }

        [Test]
        public async Task ShouldRequireUniqueName()
        {
            // await SendAsync(new CreateCityCommand
            // {
            //     Name = "Bursa"
            // });
            //
            // var command = new CreateCityCommand
            // {
            //     Name = "Bursa"
            // };
            //
            // FluentActions.Invoking(() =>
            //     SendAsync(command)).Should().Throw<ValidationException>();
        }

        [Test]
        public async Task ShouldCreateCity()
        {
            // var userId = await RunAsDefaultUserAsync();
            //
            // var command = new CreateCityCommand
            // {
            //     Name = "Kastamonu"
            // };
            //
            // var result = await SendAsync(command);
            //
            // var list = await FindAsync<City>(result.Data.Id);
            //
            // list.Should().NotBeNull();
            // list.Name.Should().Be(command.Name);
            // list.Creator.Should().Be(userId);
            // list.CreateDate.Should().BeCloseTo(DateTime.Now, 10000);
        }
    }
}
