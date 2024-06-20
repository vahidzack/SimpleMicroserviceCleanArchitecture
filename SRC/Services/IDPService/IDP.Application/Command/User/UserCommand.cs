using MediatR;
using System.ComponentModel.DataAnnotations;

namespace IDP.Application.Command.User
{
    public record UserCommand : IRequest<bool>
    {
        [Required(ErrorMessage ="این داده الزامی است")]
        [MaxLength(10)]
        public required string Name { get; set; }
    }
}
