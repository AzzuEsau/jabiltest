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
    [Route("movies/[action]")]
    public class MoviesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public MoviesController(AppDbContext context)
        {
            this._context = context;
        }

        [HttpGet("")]
        public async Task<List<Movie>> GetAllMoviesAsync()
        {
            var records = await _context.Movies.Select(x => new Movie()
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                FKclassification = x.FKclassification,
                
            }).ToListAsync();

            return records;
        }

        [HttpGet("{id}")]
        public async Task<Movie> GetMovieById([FromRoute]int id)
        {
            var record = await _context.Movies.Where(x => x.Id == id)
                .Select(x => new Movie()
                    {
                        Id = x.Id,
                        Name = x.Name,
                        Description = x.Description,
                        FKclassification = x.FKclassification,
                    }).FirstAsync();

            return record;
        }

        [HttpPost("")]
        public async Task<int> AddNewMovie([FromBody]Movie movieModel, int classificationId)
        {
            var fkclassification = await _context.Classifications.Where(x => x.Id == classificationId)
                .Select(x => new Classification
                {
                    Id = x.Id,
                    Name = x.Name
                }).FirstAsync();

            var movie = new Movie()
            {
                Name = movieModel.Name,
                Description = movieModel.Description,
                FKclassification = fkclassification,
                Update = movieModel.Update
            };

            _context.Movies.Add(movie);
            await _context.SaveChangesAsync();

            return movie.Id;
        }
    }
}
