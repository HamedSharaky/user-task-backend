using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserTask.Application.User.Queries.GetUserList;
using UserTask.Application.Users.Commands.CreateUser;
using UserTask.Application.Users.Commands.DeleteUser;
using UserTask.Application.Users.Commands.UpdateUser;
using UserTask.Application.Users.Queries.GetUserDetail;
using UserTask.Application.Users.Queries.GetUserDetail.Dtos;

namespace UserTask.WebAPI.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class UsersController : BaseController
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<UserListDto>> GetAll()
        {
            var vm = await Mediator.Send(new GetUserListQuery());

            return Ok(vm);
        }

        //[HttpGet("{id}")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<UserDetailVm>> Get(int id)
        {
            var vm = await Mediator.Send(new GetUserDetailQuery { Id = id });
            return Ok(vm);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Create([FromBody]CreateUserCommand command)
        {
           var response = await Mediator.Send(command);

            return Ok(response);
        }

        //[HttpPut("{id}")]
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Update([FromBody]UpdateUserCommand command)
        {
            var res =await Mediator.Send(command);

            return Ok(res);
        }

        //[HttpDelete("{id}")]
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Delete(int id)
        {
            var res = await Mediator.Send(new DeleteUserCommand { Id = id });

            return Ok(res);
        }
    }
}
