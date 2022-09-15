using Infrastructure.Entities.Base;
using Infrastructure.Entities.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Infrastructure.Entities
{
    [Table("Products")]
    public class Products : EntityBase<int>, IState
    {
        public Products()
        {
           
        }
        public string Name { get; set; }
        
        public string Description { get; set; }

        public decimal Price { get; set; }

        public string ImageUrl { get; set; }

        [ForeignKey("State")]
        public int StateId { get; set; }

        [JsonIgnore]
        public States State { get; set; }
    }
}
