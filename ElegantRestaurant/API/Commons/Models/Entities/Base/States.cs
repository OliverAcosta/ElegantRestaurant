using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commons.Models.Entities.Base
{
    public class States
    {
        
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }
        [Required]
        public bool Active { get; set; }


        public List<States> GetBasicStates()
        {
            return new List<States>
            {
                new States{ Id = 1, Name = "Active", Description = "The object is active in the database and can be used", Active = true },
                new States{ Id = 2, Name = "Inactive", Description = "The object is inactive in the database and cannot be used", Active = true }
            };
        }
    }
}
