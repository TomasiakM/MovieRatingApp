using Mapster;
using Users.Application.Dtos.User.Requests;
using Users.Application.Features.Users.Commands.Register;
using Users.Application.Features.Users.Commands.UpdatePassword;
using Users.Application.Features.Users.Queries.Login;

namespace Users.Application.Mapper;
internal class UserConfiguration : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<RegisterRequest, RegisterCommand>();

        config.NewConfig<LoginRequest, LoginQuery>();

        config.NewConfig<UpdatePasswordRequest, UpdatePasswordCommand>();
    }
}
