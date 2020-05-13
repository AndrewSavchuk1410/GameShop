using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameShop.Models
{
    public class Publishers
    {
        public Publishers()
        {
            GamesPublishers = new List<GamesPublishers>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Info { get; set; }

        public virtual ICollection<GamesPublishers> GamesPublishers { get; set; }
    }
}
