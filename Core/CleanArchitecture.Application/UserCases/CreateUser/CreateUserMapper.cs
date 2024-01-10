using AutoMapper;
using CleanArchitecture.Application.UseCases.CreateUser;
using CleanArchitecture.Application.UserCases.CreateUser;
using CleanArchitecture.Domain;

namespace CleanArchitecture.Application.Application.UserCases.CreateUser;

public sealed class CreateUserMapper : Profile
{
    public CreateUserMapper(){
        CreateMap<CreateUserRequest, User>();
        CreateMap<User, CreateUserResponse>();
    }
}
