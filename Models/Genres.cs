using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GameShop.Models
{
    public class Genres
    {
        public Genres()
        {
            Games = new List<Games>();
        }

        public int Id { get; set; }
        [Required(ErrorMessage = "The field has to be filled")]
        [Display(Name = "Genre")]
        public string Name { get; set; }
        [Required(ErrorMessage = "The field has to be filled")]
        [Display(Name = "Info about genre")]
        public string Info { get; set; }

        public virtual ICollection<Games> Games { get; set; }
    }
}
