using Application.Services.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using TesteThunders.Commands;

namespace TesteThunders.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TasksController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly ITasksService _taskService;

        public TasksController(ApplicationDbContext context, ITasksService tasksService)
        {
            _context = context;
            _taskService = tasksService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_taskService.GetAll());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            try
            {
                var task = _taskService.Get(id);

                if (task == null)
                {
                    return NotFound();
                }

                return Ok(task);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] CreateTaskCommand command)
        {
            try
            {
                if (command == null)
                {
                    return BadRequest();
                }

                var createdTask = _taskService.Create(command.Name, command.Description);

                return Ok(createdTask);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] UpdateTaskCommand command)
        {
            try
            {
                if (command == null)
                {
                    return BadRequest();
                }

                var updatedTask = _taskService.Update(id, command.Name, command.Description, command.IsComplete);

                if (updatedTask == null)
                {
                    return NotFound();
                }

                return Ok(updatedTask);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(long id, [FromBody] bool isComplete)
        {
            try
            {

                var updatedTask = _taskService.UpdateIsComplete(id, isComplete);

                if (updatedTask == null)
                {
                    return NotFound();
                }

                return Ok(updatedTask);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete("{id}")]
        public IActionResult DeletePerson(long id)
        {
            try
            {
                _taskService.Delete(id);

                return Ok("Task removed");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
