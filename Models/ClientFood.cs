using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Menu_x_Me_App.Models
{
    public class ClientFood
    {
        public ClientFood()
        {
            clients = new List<Client>();
        }

        public int FoodId { get; set; }
        public int ClientId { get; set; }
        public Food food { get; set; }
        public List<Client> clients { get; set; }
    }
}