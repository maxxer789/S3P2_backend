using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GroupService.Models
{
    public class Group
    {
        [Key]
        public int Id { get; set; }
        public string GroupName { get; set; }
        public ICollection<Message> Messages { get; set; }
    }
}
