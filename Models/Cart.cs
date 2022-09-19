using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Menu_x_Me_App.Models
{
    public class Cart
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductPic { get; set; }
        public float Price { get; set; }
        public int Qty { get; set; }
        public float Bill { get; set; }
    }
}