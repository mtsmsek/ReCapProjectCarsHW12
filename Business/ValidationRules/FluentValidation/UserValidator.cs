using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.FirstName).NotEmpty();
            RuleFor(u => u.LastName).NotEmpty();
            RuleFor(u => u.EMail).NotEmpty();
            RuleFor(u => u.Password).NotEmpty();
            RuleFor(u => u.Password).Must(NotContainSpace).WithMessage("Şifre boşluk karakteri içermemelidir.");

        }

        private bool NotContainSpace(string arg)
        {
            return arg.Contains(" ");
        }
    }
}
