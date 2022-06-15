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
    [Route("directors/[action]")]
    public class DirectoriesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DirectoriesController(AppDbContext context)
        {
            this._context = context;
        }

        [HttpGet("")]
        public async Task<List<Director>> GetAllDirectorsAsync()
        {
            var records = await _context.Directories.Select(x => new Director()
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Age = x.Age,
                Update = x.Update,
            }).ToListAsync();

            return records;
        }

        [HttpGet("{id}")]
        public async Task<Director> GetDirectorById([FromRoute]int id)
        {
            var record = await _context.Directories.Where(x => x.Id == id)
                .Select(x => new Director()
                    {
                        Id = x.Id,
                        FirstName = x.FirstName,
                        LastName = x.LastName,
                        Age = x.Age,
                        Update = x.Update,
                    }).FirstAsync();

            return record;
        }

        [HttpPost("")]
        public async Task<int> AddNewDirector([FromBody]Director diretorModel)
        {
            var director = new Director()
            {
                FirstName = diretorModel.FirstName,
                LastName = diretorModel.LastName,
                Age = diretorModel.Age,
                Update = DateTime.Now
            };

            _context.Directories.Add(director);
            await _context.SaveChangesAsync();

            return director.Id;
        }

        [HttpPut("{id}")]
        public async Task UpdateDirectorById([FromRoute]int id, [FromBody]Director diretorModel)
        {
            var record = await _context.Directories.FindAsync(id);

            if (record != null)
            {
                record.FirstName = diretorModel.FirstName;
                record.LastName = diretorModel.LastName;
                record.Age = diretorModel.Age;
                record.Update = DateTime.Now;
            }

            await _context.SaveChangesAsync();
        }
    }
}
