using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Persistence;

namespace API.Controller
{
    public class ActivitiesController : BaseController
    {
        private readonly DataContext _context;
        public ActivitiesController(DataContext dataContext)
        {
            _context = dataContext;
        }

        [HttpGet] // /api/activities
        public async Task<ActionResult<List<Activity>>> GetActivities()
        {
            return await _context.Activities.ToListAsync();
        }

        [HttpGet("{id}")] // /api/activities/asadsdafsfgfdg
        public async Task<ActionResult<Activity>> GetActivity(Guid id)
        {
            return await _context.Activities.FindAsync(id);
        }


    }
}