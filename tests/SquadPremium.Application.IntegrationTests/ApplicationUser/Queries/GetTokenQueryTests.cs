using System.Threading.Tasks;
using NUnit.Framework;
using SquadPremium.Application.ApplicationUser.Queries.GetToken;

namespace SquadPremium.Application.IntegrationTests.ApplicationUser.Queries
{
    public class GetTokenQueryTests : TestBase
    {
        [Test]
        public async Task ShouldAuthenticateAndReturnJwtToken()
        {
            // await AddAsync(new LoginResponse()
            // {
            //     
            // });
            //
            // var query = new GetTokenQuery();
            //
            // var result = await SendAsync(query);
            //
            // result.Should().NotBeNull();
            // result.Succeeded.Should().BeTrue();
            // result.Data.Count.Should().BeGreaterThan(0);
        }
        
      
    }
}