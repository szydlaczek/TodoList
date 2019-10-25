using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TodoList.Application.Helpers;
using TodoList.Application.TaskItems.Commands.CreateTaskItem;
using TodoList.Application.TaskItems.Commands.EndTask;
using TodoList.Application.TaskItems.Commands.StartTask;
using TodoList.Application.TaskItems.Queries.GetTasks;

namespace TodoList.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        // GET api/values
        private readonly IMediator _mediator;
        public TasksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]GetTasksQuery query)
        {            
            var queryResult = await _mediator.Send(query);
            return Ok(((SuccessResponse)queryResult));
        }
        
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CreateTaskItemCommand command)
        {
            var commandResult = await _mediator.Send(command);
            return Created("Id", ((SuccessResponse)commandResult).Data);
        }

        [HttpPut("{id}/start")]
        public async Task<IActionResult> Start(Guid id)
        {
            var command = new StartTaskCommand(id);
            var commandResult = await _mediator.Send(command);

            if (commandResult is SuccessResponse)
                return Ok();
            else
                return BadRequest((ErrorResponse)commandResult);
        }

        [HttpPut("{id}/stop")]
        public async Task<IActionResult> Stop(Guid id)
        {
            var command = new EndTaskCommand(id);
            var commandResult = await _mediator.Send(command);

            if (commandResult is SuccessResponse)
                return Ok();
            else
                return BadRequest();
        }
    }
}
