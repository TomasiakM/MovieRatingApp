using Common.Application.Interfaces;
using Users.Domain.Aggregates.Users;

namespace Users.Application.Interfaces;
public interface IUnitOfWork : IBaseUnitOfWork
{
    IUserRepository Users { get; }
}
