using Application.Activities;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Controllers;

public class ActivitiesController : BaseApiController
{
    [HttpGet]
    public async Task<ActionResult<List<Activity>>?> GetActivities() 
    {
        if (Mediator is null) return new List<Activity>();
        return await Mediator.Send(new List.Query());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Activity?>?> GetActivity(Guid id) 
    {
        if(Mediator is null) return null;
        return await Mediator.Send(new Details.Query { Id = id });
    }

    [HttpPost]
    public async Task<IActionResult> CreateActivity(Activity activity) 
    {
        if(Mediator is null) return Ok();
        var result = await Mediator.Send(new Create.Command { Activity = activity });
        return Ok(result);
    }

    [HttpPost("{id}")]
    public async Task<IActionResult> EditActivity(Guid id, Activity activity) 
    {
        if(Mediator is null) return Ok();
        activity.Id = id;
        var result = await Mediator.Send(new Edit.Command { Activity = activity });
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteActivity(Guid id) 
    {
        if(Mediator is null) return Ok();
        var result = await Mediator.Send(new Delete.Command { Id = id });
        return Ok(result);
    }
}