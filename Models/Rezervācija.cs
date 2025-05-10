using System.ComponentModel.DataAnnotations;

namespace AutoNomā.Models
{
    public class Rezervācija
    {
        public int Id { get; set; }

        public int? LietotājaId { get; set; }

        public int AutoId { get; set; }

        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        public string? Statuss { get; set; }
        public Auto? Auto { get; set; }

    }
}

