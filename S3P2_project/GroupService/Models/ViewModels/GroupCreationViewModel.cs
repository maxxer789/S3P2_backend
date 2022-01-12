using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GroupService.Models.ViewModels
{
    public class GroupCreationViewModel
    {
        public int Id { get; set; }
        [Required]
        public string GroupName { get; set; }
    }
}
