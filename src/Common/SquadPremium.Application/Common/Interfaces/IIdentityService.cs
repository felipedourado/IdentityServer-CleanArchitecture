using System.Threading.Tasks;
using SquadPremium.Application.Common.Models;
using SquadPremium.Application.Dto;

namespace SquadPremium.Application.Common.Interfaces
{
    public interface IIdentityService
    {
        Task<string> GetUserNameAsync(string userId);

        Task<ApplicationUserDto> CheckUserPassword(string userName, string password);

        Task<(Result Result, string UserId)> CreateUserAsync(string userName, string password);

        Task<bool> UserIsInRole(string userId, string role);
        
    }
}
