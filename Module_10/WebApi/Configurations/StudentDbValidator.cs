namespace WebApi.Configurations
{
    using DataAccess.Models;
    using FluentValidation;

    public class StudentDbValidator : AbstractValidator<StudentDb>
    {
        public StudentDbValidator()
        {
            RuleFor(x => x.Email).EmailAddress().NotEmpty().NotNull();
            RuleFor(x => x.Name).NotNull().NotEmpty();
            RuleFor(x => x.Tel).NotNull().NotEmpty();
        }
    }
}