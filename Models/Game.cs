using GameStore.Api.Models;

namespace GameStore.Api.Models
{
    public class Game
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public Genre? Gemre { get; set; }
        public int GenreId { get; set; }
        public decimal price { get; set; }
        public DateOnly ReleaseDate { get; set; }
    }
}