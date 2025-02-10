using Microsoft.Identity.Client;

namespace Selu383.SP25.Api.Entities
{
    public class TheaterDto
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Address { get; set; }
        public int seatCount { get; set; }
    }

    public class TheaterGetDto
    {
        public String Name { get; set; }
        public String Address { get; set; }
        public int seatCount { get; set; }
    }

    public class TheaterCreateDto
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Address { get; set; }
        public int seatCount
        {
            get; set;
        }
    }
}
