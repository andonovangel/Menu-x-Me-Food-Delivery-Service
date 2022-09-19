using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace Menu_x_Me_App.Models
{
    public class InvoiceModel
    {
        [Key]
        public int ID { get; set; }

        public DateTime? DateInvoice { get; set; }
        public float Total_Bill { get; set; }

        public int? FKUserID { get; set; }
    }
}