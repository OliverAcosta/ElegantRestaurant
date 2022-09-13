using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities
{
    [Table("Sales")]
    public class Sales
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int ProductId { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public DateTime SellTime { get; set; }
        public int StateId { get; set; }

        public States States { get; set; }
    }
}
