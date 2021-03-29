using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TicketSystem.Models
{
    public class SprintNum
    {
        [Key]
        public string SprintNumId { get; set; }
        public string Name { get; set; }
    }
}
