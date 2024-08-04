using Asp.Versioning;
using IDP.Api.Controllers.BaseController;
using IDP.Application.Command.Auth;
using IDP.Application.Command.User;
using IDP.Application.Query.Auth;
using IDP.Domain.DTO;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IDP.Api.Controllers.V1
{
    [Route("api/v1/user")]
    [ApiController]
    [ApiVersion(1)]
    public class UserController : IBaseController
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// ورود اطلاعات کاربر
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [MapToApiVersion(1)]
        [HttpPost("Insert")]
        public async Task<IActionResult> AddUser([FromBody] UserCommand user)
        {
            var res = await _mediator.Send(user);
            return Ok(res);
        }

        /// <summary>
        /// ثبت نام و ارسال کد به شماره موبایل کاربر
        /// </summary>
        /// <param name="auth"></param>
        /// <returns></returns>
        [HttpPost("RegisterAndSendOtp")]
        public async Task<IActionResult> RegisterAndSendOtp([FromBody] AuthCommand auth)
        {
            var res = await _mediator.Send(auth);
            return Ok(res);
        }
    }
}
