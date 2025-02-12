using Microsoft.AspNetCore.Mvc;
using Selu383.SP25.Api.Entities;
using Selu383.SP25.Api.DTO;


namespace Selu383.SP25.Api.Controllers

{
    [ApiController]
    [Route("/api/[controller]")]
    public class TheatersController : ControllerBase
    {
        // declaring dbcontext
        private readonly DataContext _db;

        public TheatersController(DataContext db)
        {
            _db = db;
        }

        // GET api/theaters
        [HttpGet]
        public IActionResult GetAll()
        {
        var theaters = _db.Theaters
            .Select(b => new Theater
            {
                Id = b.Id,
                Name = b.Name,
                Address = b.Address,
                SeatCount = b.SeatCount,
            }).ToList();

            return Ok(theaters);
        }

        // Get By ID api/theaters
        [HttpGet("{id}")]
        public IActionResult GetTheaterById(int id)
        {
            // Find the theater by ID
            var theater = _db.Theaters.FirstOrDefault(t => t.Id == id);

            // If not found, return 404 Not Found
            if (theater == null)
            {
                return NotFound($"Theater with ID {id} not found.");
            }

            // Return the found theater
            return Ok(new Theater
            {
                Id = theater.Id,
                Name = theater.Name,
                Address = theater.Address,
                SeatCount = theater.SeatCount
            });
        }


        // POST api/Theaters
        [HttpPost]
        public IActionResult CreateTheater([FromBody] TheaterCreateDto theaterDto)
        {
            if (theaterDto == null)
            {
                return BadRequest("Invalid data.");
            }

            var theater = new Theater
            {
                Name = theaterDto.Name,
                Address = theaterDto.Address,
                SeatCount = theaterDto.SeatCount
            };

            _db.Theaters.Add(theater);
            _db.SaveChanges();

            return CreatedAtAction(nameof(GetAll), new { id = theater.Id }, new Theater
            {
                Id = theater.Id,
                Name = theater.Name,
                Address = theater.Address,
                SeatCount = theater.SeatCount
            });

        }

        // PUT/update by Id
        [HttpPut("{id}")]
        public IActionResult UpdateTheater(int id, [FromBody] TheaterUpdateDto theaterDto)
        {
            // Validate input
            if (theaterDto == null)
            {
                return BadRequest("Invalid data.");
            }

            // Find the theater by ID
            var theater = _db.Theaters.FirstOrDefault(t => t.Id == id);
            if (theater == null)
            {
                return NotFound("Theater not found.");
            }

            // Update theater properties
            theater.Name = theaterDto.Name;
            theater.Address = theaterDto.Address;
            theater.SeatCount = theaterDto.SeatCount;

            // Save changes to the database
            _db.SaveChanges();

            // Return updated theater data
            return Ok(new Theater
            {
                Id = theater.Id,
                Name = theater.Name,
                Address = theater.Address,
                SeatCount = theater.SeatCount
            });
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTheater(int id)
        {
            // Find the theater by ID
            var theater = _db.Theaters.FirstOrDefault(t => t.Id == id);

            // If not found, return 404 Not Found
            if (theater == null)
            {
                return NotFound($"Theater with ID {id} not found.");
            }

            // Remove the theater from the database
            _db.Theaters.Remove(theater);
            _db.SaveChanges();

            // Return a successful response
            return NoContent(); // Status 204: No Content
        }
    }
}
