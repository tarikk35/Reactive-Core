using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Activities;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    // To debug API on VSCODE, debug using .NET Core Attach instead of .NET Core Launch.
    // Run the debugger and Attach your process to API.dll

    public class ActivitiesController : BaseController
    {

        [HttpGet]
        // If user cancels the request or there's no user to take it, we can cancel it using cancellation token
        public async Task<ActionResult<List<ActivityDto>>> List(CancellationToken ct)
        {
            // GET the list from Application Layer using MediatR
            return await Mediator.Send(new List.Query(), ct);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ActivityDto>> Details(Guid id)
        {
            return await Mediator.Send(new Details.Query { Id = id });
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> Create(Create.Command command)
        {
            // Our [APIController] does check if ModelState has any errors

            // if(!ModelState.IsValid){
            //     return BadRequest(ModelState);
            // }
            return await Mediator.Send(command);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Unit>> Edit(Guid id, Edit.Command command)
        {
            command.Id = id;
            return await Mediator.Send(command);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> Delete(Guid id)
        {
            return await Mediator.Send(new Delete.Command { Id = id });
        }
    }
}
