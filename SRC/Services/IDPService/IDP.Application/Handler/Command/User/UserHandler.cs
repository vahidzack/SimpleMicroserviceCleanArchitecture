using IDP.Application.Command.User;
using MediatR;

namespace IDP.Application.Handler.Command.User
{
    public class UserHandler : IRequestHandler<UserCommand, bool>
    {
        public Task<bool> Handle(UserCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
