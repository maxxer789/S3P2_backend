using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AccountService.Models
{
    public class Account
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(30)")]
        public string Username { get; set; }
        public string Password { get; set; }

        public virtual ICollection<AccountPost> Posts { get; set; }
    }
}
