using Asp.Versioning;
using IDP.Api.Controllers.BaseController;
using Microsoft.AspNetCore.Mvc;

namespace IDP.Api.Controllers.V1
{
    [Route("api/v1/user")]
    [ApiController]
    [ApiVersion(1)]
    public class UserController : IBaseController
    { 
    }
}
