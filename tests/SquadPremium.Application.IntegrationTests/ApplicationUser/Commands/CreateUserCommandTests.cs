using System;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using SquadPremium.Application.Common.Security;

namespace SquadPremium.Application.IntegrationTests.ApplicationUser.Commands
{
    public class CreateUserCommandTests : TestBase
    {
        [Test]
        public async Task ShouldCreateUser()
        {
            // await AddAsync(new City
            // {
            //     Name = "Manisa",
            // });
            //
            // var query = new GetAllCitiesQuery();
            //
            // var result = await SendAsync(query);
            //
            // result.Should().NotBeNull();
            // result.Succeeded.Should().BeTrue();
            // result.Data.Count.Should().BeGreaterThan(0);
        }
        
        [Test]
        public async Task ShouldRequireRulesPassword()
        {
            // await AddAsync(new City
            // {
            //     Name = "Manisa",
            // });
            //
            // var query = new GetAllCitiesQuery();
            //
            // var result = await SendAsync(query);
            //
            // result.Should().NotBeNull();
            // result.Succeeded.Should().BeTrue();
            // result.Data.Count.Should().BeGreaterThan(0);
        }
        
        [Test]
        public async Task ShouldRevokeJwtExpired()
        {
            // await AddAsync(new City
            // {
            //     Name = "Manisa",
            // });
            //
            // var query = new GetAllCitiesQuery();
            //
            // var result = await SendAsync(query);
            //
            // result.Should().NotBeNull();
            // result.Succeeded.Should().BeTrue();
            // result.Data.Count.Should().BeGreaterThan(0);
        }
        
        [Test]
        public void ShouldDenyAnonymousUser()
        {
            // var query = new ExportDistrictsQuery();
            //
            // query.GetType().Should().BeDecoratedWith<AuthorizeAttribute>();
            //
            // FluentActions.Invoking(() =>
            //     SendAsync(query)).Should().Throw<UnauthorizedAccessException>();
        }
    }
}