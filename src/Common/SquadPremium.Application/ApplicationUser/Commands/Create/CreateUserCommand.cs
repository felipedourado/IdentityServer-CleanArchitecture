using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using SquadPremium.Application.ApplicationUser.Queries.GetToken;
using SquadPremium.Application.Common.Interfaces;
using SquadPremium.Application.Common.Models;

namespace SquadPremium.Application.ApplicationUser.Commands.Create
{
    public class CreateUserCommand : IRequestWrapper<LoginResponse>
    {
        public string Password { get; set; }
        public string Email { get; set; }
    }
    
    public class CreateUserCommandHandler : IRequestHandlerWrapper<CreateUserCommand, LoginResponse>
    {
        private readonly IIdentityService _identityService;
    
        public CreateUserCommandHandler(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        public async Task<ServiceResult<LoginResponse>> Handle(CreateUserCommand request, 
            CancellationToken cancellationToken)
        {

            var result = new CreateUserCommandValidator().Validate(request);
            
            if (!result.IsValid)
            {
                return ServiceResult.Failed<LoginResponse>(ServiceError.Validation);
            }
            
            await _identityService.CreateUserAsync(request.Email, request.Password);

            return ServiceResult.Success(new LoginResponse { });
        }
    }
}