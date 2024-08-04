using IDP.Domain.DTO;
using IDP.Domain.IRepository.Command.Base;

namespace IDP.Domain.IRepository.Command
{
    public interface IOtpRedisRepository : ICommandRepository<Otp>
    {

    }
}
