using GameStore.Api.Models;
using GameStore.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Api.Data
{
    public class GameStoreContext(DbContextOptions<GameStoreContext> options)
    : DbContext(options)
    {
        // token
        public DbSet<User> Users => Set<User>();
        // games
        public DbSet<Game> Games => Set<Game>();
        public DbSet<Genre> Genres => Set<Genre>();
    }
}