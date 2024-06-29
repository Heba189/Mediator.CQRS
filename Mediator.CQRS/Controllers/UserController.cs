using Mediator.CQRS.Commands;
using Mediator.CQRS.Interfaces;
using Mediator.CQRS.Models;
using Mediator.CQRS.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Mediator.CQRS.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        // private readonly IUserServices _services;
        private readonly IMediator _mediator;
        public UserController(IMediator mediator)
        {
            //_services = services;
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<ActionResult<List<UserModel>>> GetAllUsers()
        {
            //return _services.GetUsers();
            var query = new ReadUsersQuery();
             var oResult = await _mediator.Send(query);
            return Ok(oResult);
        }

        [HttpGet("{index}")]
        public async Task<ActionResult<UserModel>> GetAllUserByIndex(int index)
        {
            var query = new ReadUserByIndexQuery(index);
            var oResult = await _mediator.Send(query);
            return Ok(oResult);
        }
        [HttpPost]
        public async Task<ActionResult<UserModel>> AddNewUser(UserModel user)
        {
            var command = new AddUserCommand(user.Id,
                                             user.FirstName,
                                             user.LastName);
            var oResult = await _mediator.Send(command);
            return Ok(oResult);
        }
    }
}
