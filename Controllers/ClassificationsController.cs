using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

using api.Data;

namespace api.Controllers
{
    [ApiController]
    [Route("classifications/[action]")]
    public class ClasssificationsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ClasssificationsController(AppDbContext context)
        {
            this._context = context;
        }

        [HttpGet("")]
        public async Task<List<Classification>> GetAllClassificationsAsync()
        {
            var records = await _context.Classifications.Select(x => new Classification()
            {
                Id = x.Id,
                Name = x.Name,
            }).ToListAsync();

            return records;
        }
    }
}
