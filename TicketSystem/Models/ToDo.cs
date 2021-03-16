using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TicketSystem.Models
{
    public class ToDo
    {
        public int TicketID { get; set; }

        [Required(ErrorMessage = "Please enter Name.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter Description.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Please enter Description.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter Name.")]
        public string Name { get; set; }
    }
}
