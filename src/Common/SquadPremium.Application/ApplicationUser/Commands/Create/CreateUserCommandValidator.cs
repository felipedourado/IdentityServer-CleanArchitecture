using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using SquadPremium.Application.Common.Interfaces;

namespace SquadPremium.Application.ApplicationUser.Commands.Create
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
      //private readonly IApplicationDbContext _context;
        
        public CreateUserCommandValidator()
        {
            //_context = context;

            RuleFor(v => v.Password)
                .MinimumLength(15).WithMessage("Senha deve ter no minimo 15 caracteres.")
                .NotEmpty().WithMessage("Senha é obrigatória.")
                .Matches(@"[A-Z]+").WithMessage("Senha deve conter uma letra maiuscula.")
                .Matches(@"[a-z]+").WithMessage("Senha deve conter uma letra minuscula.")
                .Matches(@"[0-9]+").WithMessage("Senha deve conter numero.")
                //.Matches(@"[\!\?\.]+").WithMessage("Senha deve conter caracter especial (!? *.).");
                .Matches(@"(\\W)+")
                .WithMessage("Senha deve conter caracter especial.");
        }
    }
}