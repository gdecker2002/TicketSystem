using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TicketSystem.Models
{
    public class ToDo
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter Name.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter Description.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Please enter Sprint Number.")]
        public string SprintNumId { get; set; }
        public SprintNum SprintNum { get; set; }

        [Required(ErrorMessage = "Please enter Point Value.")]
        public string PointId { get; set; }
        public Point Point { get; set; }

        [Required(ErrorMessage = "Please enter Status.")]
        public string StatusId { get; set; }
        public Status Status { get; set; }
    }
}
