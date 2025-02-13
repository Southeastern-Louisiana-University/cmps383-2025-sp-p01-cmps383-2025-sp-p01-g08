using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Selu383.SP25.Api;
using Selu383.SP25.Api.Entities;
using Selu383.SP25.Api.DTO;

namespace Selu383.SP25.Api.Controllers
{
    [ApiController]
    [Route("api/theaters")]
    public class TheatersController : ControllerBase
    {
        private readonly DataContext _db;

        public TheatersController(DataContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var theaters = _db.Theaters
                .Select(t => new TheaterGetDto
                {
                    Id = t.Id,
                    Name = t.Name,
                    Address = t.Address,
                    SeatCount = t.SeatCount
                })
                .ToList();
            return Ok(theaters);
        }

        [HttpGet("{id}", Name = "GetTheaterById")]
        public IActionResult GetTheaterById(int id)
        {
            var theater = _db.Theaters.FirstOrDefault(t => t.Id == id);
            if (theater == null) return NotFound();
            var dto = new TheaterGetDto
            {
                Id = theater.Id,
                Name = theater.Name,
                Address = theater.Address,
                SeatCount = theater.SeatCount
            };
            return Ok(dto);
        }

        [HttpPost]
        public IActionResult CreateTheater([FromBody] TheaterCreateDto dto)
        {
            if (dto == null) return BadRequest();
            if (string.IsNullOrWhiteSpace(dto.Name)) return BadRequest();
            if (dto.Name.Length > 120) return BadRequest();
            if (string.IsNullOrWhiteSpace(dto.Address)) return BadRequest();
            if (dto.SeatCount == null || dto.SeatCount == 0) return BadRequest();

            var entity = new Theater
            {
                Name = dto.Name,
                Address = dto.Address,
                SeatCount = dto.SeatCount
            };
            _db.Theaters.Add(entity);
            _db.SaveChanges();
            var result = new TheaterGetDto
            {
                Id = entity.Id,
                Name = entity.Name,
                Address = entity.Address,
                SeatCount = entity.SeatCount
            };
            return CreatedAtRoute("GetTheaterById", new { id = entity.Id }, result);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTheater(int id, [FromBody] TheaterUpdateDto dto)
        {
            if (dto == null) return BadRequest();
            if (string.IsNullOrWhiteSpace(dto.Name)) return BadRequest();
            if (dto.Name.Length > 120) return BadRequest();
            if (string.IsNullOrWhiteSpace(dto.Address)) return BadRequest();
            var theater = _db.Theaters.FirstOrDefault(t => t.Id == id);
            if (theater == null) return NotFound();
            theater.Name = dto.Name;
            theater.Address = dto.Address;
            theater.SeatCount = dto.SeatCount;
            _db.SaveChanges();
            var result = new TheaterGetDto
            {
                Id = theater.Id,
                Name = theater.Name,
                Address = theater.Address,
                SeatCount = theater.SeatCount
            };
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTheater(int id)
        {
            var theater = _db.Theaters.FirstOrDefault(t => t.Id == id);
            if (theater == null) return NotFound();
            _db.Theaters.Remove(theater);
            _db.SaveChanges();
            return Ok();
        }
    }
}
