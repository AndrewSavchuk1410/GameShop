using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace GameShop.Models
{
    public class GameShopContext : DbContext
    {
        public virtual DbSet<Publishers> Publishers { get; set; }
        public virtual DbSet<GamesPublishers> GamesPublishers { get; set; }
        public virtual DbSet<Games> Games { get; set; }
        public virtual DbSet<Genres> Genres { get; set; }

        public GameShopContext(DbContextOptions<GameShopContext> options)
            :base(options)
        {
            Database.EnsureCreated();
        }
    }
}
