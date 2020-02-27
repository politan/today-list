using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TodayList.Application.Assignments.Commands.CreateAssignment;
using TodayList.Application.Assignments.Commands.DeleteAssignment;
using TodayList.Application.Assignments.Commands.UpdateAssignment;
using TodayList.Application.Assignments.Queries.GetAssignments;
using TodayList.Application.DTO;

namespace TodayList.Api.Controllers
{
    public class AssignmentsController : BaseController
    {
        [HttpGet]
        public async Task<IEnumerable<AssignmentDto>> Get()
        {
            return await Mediator.Send(new GetAssignmentsQuery());
        }

        [HttpGet("{id}")]
        public async Task<AssignmentDto> Get(Guid id)
        {
            return default;
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create(CreateAssignmentCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(Guid id, UpdateAssignmentCommand command)
        {
            if (!id.Equals(command.Id))
            {
                return BadRequest();
            }

            await Mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            await Mediator.Send(new DeleteAssignmentCommand { Id = id });

            return NoContent();
        }
    }
}