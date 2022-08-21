using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Menu_x_Me_App.Models
{
    public class Client
    {
        public Client()
        {
            foods = new List<Food>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string PhoneNum { get; set; }

        public virtual ICollection<Food> foods { get; set; }
    }
}