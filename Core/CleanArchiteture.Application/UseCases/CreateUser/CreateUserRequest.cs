
using MediatR;

namespace CleanArchitecture.Application.UseCases.CreateUser;
public sealed record CreateUserRequest(String Email, string Name):IRequest<CreateUserResponse>{}