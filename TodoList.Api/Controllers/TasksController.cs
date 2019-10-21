using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TodoList.Application.TaskItems.Commands.CreateTaskItem;
using TodoList.Application.TaskItems.Queries.GetTasks;

namespace TodoList.Api.Controllers
{
    [Route("api/[controller]")]
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
            return Ok(queryResult.Data);
        }
        
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CreateTaskItemCommand command)
        {
            var commandResult = await _mediator.Send(command);

        }
    }
}
