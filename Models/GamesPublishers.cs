using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameShop.Models
{
    public class GamesPublishers
    {
        public int GameId { get; set; }
        public int PublisherId { get; set; }
        public int Id { get; set; }

        public virtual Publishers Publishers { get; set; }
        public virtual Games Games { get; set; }
    }
}
