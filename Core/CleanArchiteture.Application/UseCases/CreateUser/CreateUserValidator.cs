namespace CleanArchitecture.Application.UseCases.CreateUser;

using FluentValidation;

public sealed class CreateUserValidator : AbstractValidator<CreateUserRequest>{
    public CreateUserValidator(){
        RuleFor(x => x.Email).NotEmpty().MaximumLength(50).WithMessage("Email invalido").Must(x => x.Contains("@")).WithMessage("Email invalido").EmailAddress();
        RuleFor(x => x.Name).NotEmpty().MinimumLength(3).MaximumLength(50);
    }
}