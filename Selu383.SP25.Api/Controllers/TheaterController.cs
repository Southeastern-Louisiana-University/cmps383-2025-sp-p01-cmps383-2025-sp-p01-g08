using System.Web.Http;
using System.Web.Http.Description;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Selu383.SP25.Api.Entities;

namespace Selu383.SP25.Api.Controllers

{
    [ApiController]
    [Microsoft.AspNetCore.Mvc.Route("[controller]")]
    public class TheaterController : Controller
    {
        private MyDataContext db;

        // GET api/Theaters
        [Microsoft.AspNetCore.Mvc.HttpGet(Name = "GetTheaterDto")]
        public IQueryable<TheaterDto> GetTheaters()
        {
            var theaters = from b in db.Theaters
                        select new TheaterDto()
                        {
                            Id = b.Id,
                            Name = b.Name,
                            Address = b.Address,
                            seatCount = b.seatCount,
                        };

            return theaters;
        }
    }
}
