using Microsoft.Identity.Client;

namespace Selu383.SP25.Api.NewFolder
{
    public class TheaterGetDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int SeatCount { get; set; }
    }

    public class TheaterCreateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int SeatCount { get; set; }
    }
}
