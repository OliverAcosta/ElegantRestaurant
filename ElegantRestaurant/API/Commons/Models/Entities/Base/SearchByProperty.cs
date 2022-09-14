
using Commons.Reflection.Models;
using System.ComponentModel.DataAnnotations;

namespace Commons.Models.Entities.Base
{
    public class SearchByProperty
    {
        private int max = 100;
        private int page = 0;
        public PropertyBase[] ORProperties { get; set; }
        public PropertyBase[] EqualsProperties { get; set; }
        [Required]
        public int Page { get { return page; } set { if (value >= 0) { page = value; } else throw new ArgumentException("Page cannot be less than 0"); } }
        [Required]
        public int PageSize { get { return max; } set { if (value > 0 && value <= 100) { max = value; } else throw new ArgumentException("PageSize cannot be more than 100"); } }
    }
}
