using Infrastructure.Entities.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Infrastructure.Entities
{
    [Table("Products")]
    public class Products : IIdentity<int>
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        
        public string Description { get; set; }
        [Required]
        public decimal Price { get; set; }

        public string ImageUrl { get; set; }

        public int StatesId { get; set; }

        public States States { get; set; }
    }
}
