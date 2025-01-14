using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application;
using Application.Activities;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Persistence;

namespace API.Controller
{
    public class ActivitiesController : BaseController
    {       
        [HttpGet] // /api/activities
        public async Task<ActionResult<List<Activity>>> GetActivities()
        {
            return await Mediator.Send(new List.Query());
        }

        [HttpGet("{id}")] // /api/activities/asadsdafsfgfdg
        public async Task<ActionResult<Activity>> GetActivity(Guid id)
        {
            return await Mediator.Send(new Details.Query{Id = id});
        }

        [HttpPost]
        public async Task<ActionResult> CreateActivity([FromBody]Activity activity)
        {
            await Mediator.Send(new Creates.Command{ Activity = activity});

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateActivity(Guid id,[FromBody]Activity activity)
        {
            activity.Id = id;

            await Mediator.Send(new Edit.Command{ Activity = activity });

            return Ok();
        }
    }
}