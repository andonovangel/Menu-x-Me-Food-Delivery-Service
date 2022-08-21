using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Menu_x_Me_App.Models
{
    public class Food
    {
        public Food()
        {
            clients = new List<Client>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string ImageURL { get; set; }

        public virtual ICollection<Client> clients { get; set; }
    }
}