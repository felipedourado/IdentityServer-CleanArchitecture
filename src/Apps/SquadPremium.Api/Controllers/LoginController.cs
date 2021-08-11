using System.Threading.Tasks;
using SquadPremium.Application.ApplicationUser.Queries.GetToken;
using SquadPremium.Application.Common.Models;
using Microsoft.AspNetCore.Mvc;

namespace SquadPremium.Api.Controllers
{
    public class LoginController : BaseApiController
    {
        [HttpPost]
        public async Task<ActionResult<ServiceResult<LoginResponse>>> Create(GetTokenQuery query)
        {
            return Ok(await Mediator.Send(query));
        }
    }
}
