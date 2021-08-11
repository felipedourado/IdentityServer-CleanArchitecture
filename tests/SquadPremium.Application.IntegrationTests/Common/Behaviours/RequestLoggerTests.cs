using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using SquadPremium.Application.Common.Behaviours;
using SquadPremium.Application.Common.Interfaces;
using Moq;
using NUnit.Framework;
using SquadPremium.Application.ApplicationUser.Commands.Create;

namespace SquadPremium.Application.IntegrationTests.Common.Behaviours
{
    public class RequestLoggerTests
    {
        private readonly Mock<ILogger<CreateUserCommand>> _logger;
        private readonly Mock<ICurrentUserService> _currentUserService;
        private readonly Mock<IIdentityService> _identityService;

        public RequestLoggerTests()
        {
            _currentUserService = new Mock<ICurrentUserService>();
            _logger = new Mock<ILogger<CreateUserCommand>>();
            _identityService = new Mock<IIdentityService>();
        }

        [Test]
        public async Task ShouldCallGetUserNameAsyncOnceIfAuthenticated()
        {
            _currentUserService.Setup(x => x.UserId).Returns("Administrator");

            var requestLogger = new LoggingBehaviour<CreateUserCommand>(_logger.Object, _currentUserService.Object, _identityService.Object);

            await requestLogger.Process(new CreateUserCommand { Email = "bruce@test.com" }, new CancellationToken());

            _identityService.Verify(i => i.GetUserNameAsync(It.IsAny<string>()), Times.Once);
        }

        [Test]
        public async Task ShouldNotCallGetUserNameAsyncOnceIfUnauthenticated()
        {
            var requestLogger = new LoggingBehaviour<CreateUserCommand>(_logger.Object, _currentUserService.Object, _identityService.Object);

            await requestLogger.Process(new CreateUserCommand { Email = "bruce@test.com" }, new CancellationToken());

            _identityService.Verify(i => i.GetUserNameAsync(null), Times.Never);
        }
    }
}
