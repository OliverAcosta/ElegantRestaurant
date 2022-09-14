
using Commons.Entities.Models.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Commons.Models.Entities.Base
{
    public class Descriptionable<T> : EntityBase<T>, IDescriptionable
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
       
        public int StateId { get; set; }
        
    }
}
