using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Selu383.SP25.Api.Entities;

namespace Selu383.SP25.Api.Controllers

{
    [ApiController]
    [Route("api/[controller]")]
    public class TheaterController : ControllerBase
    {
            private readonly MyDataContext _db;

            public TheaterController(MyDataContext db)
            {
                _db = db;
            }

            // GET api/Theaters
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
        }
     }
