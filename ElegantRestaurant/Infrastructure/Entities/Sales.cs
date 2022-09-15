
using Infrastructure.Entities.Base;
using Infrastructure.Entities.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Infrastructure.Entities
{
    [Table("Sales")]
    public class Sales : EntityBase<int>, IState
    {
        
        public int ProductId { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public DateTime SellTime { get; set; }

        [ForeignKey("State")]
        public int StateId { get; set; }

        [JsonIgnore]
        public States State { get; set; }
    }
}
