using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GroupService.Models.ViewModels
{
    public class GroupViewModel
    {
        [Required]
        public int Id { get; set; }
        public string GroupName { get; set; }
        public ICollection<Message> Messages { get; set; }
    }
}
