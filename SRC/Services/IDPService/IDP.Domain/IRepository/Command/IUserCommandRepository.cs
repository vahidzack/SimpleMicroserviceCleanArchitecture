using IDP.Domain.Entities;
using IDP.Domain.IRepository.Command.Base;

namespace IDP.Domain.IRepository.Command
{
    public interface IUserCommandRepository : ICommandRepository<User>
    {

    }
}
