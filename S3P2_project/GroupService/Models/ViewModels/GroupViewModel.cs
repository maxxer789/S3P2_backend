using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
