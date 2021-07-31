using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Persistence;
using Domain;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System;

namespace API.Controllers
{
    public class ActivitiesController : BaseApiController
    {
        private readonly DataContext _context;

        // Query database directly inside here and return activities to client
        public ActivitiesController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Activity>>> GetActivities()
        {
            return await _context.Activities.ToListAsync();
        }

        [HttpGet("{id}")] // activities/id
        public async Task<ActionResult<Activity>> GetActivity(Guid id)
        {
            return await _context.Activities.FindAsync(id); // Use FindAsync to find ID passed in from method
        }
    }
}