using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using SquadPremium.Application.ApplicationUser.Commands.Create;
using SquadPremium.Application.ApplicationUser.Queries.GetToken;
using SquadPremium.Application.Common.Models;
using Microsoft.AspNetCore.Mvc;

namespace SquadPremium.Api.Controllers
{
    //[Authorize]
    public class UserController: BaseApiController
    {
        [HttpPost]
        public async Task<ActionResult<ServiceResult<LoginResponse>>> Create(CreateUserCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}