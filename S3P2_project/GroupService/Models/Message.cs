using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GroupService.Models
{
    public class Message
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        [MaxLength(150)]
        public string Text { get; set; }
    }
}
