using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AccountService.Models
{
    public class AccountPost
    {
        [Key]
        public int Id { get; set; }
        public int AccountId { get; set; }
        public int PostId { get; set; }
    }
}
