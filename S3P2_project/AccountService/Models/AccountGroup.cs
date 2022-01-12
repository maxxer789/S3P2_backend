using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AccountService.Models
{
    public enum GroupRole
    {
        Owner = 1,
        Admin,
        Moderator,
        Poster,
        Attendee
    }

    public class AccountGroup
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Account")]
        public int AccountId { get; set; }
        public int GroupId { get; set; }
        public GroupRole Role;
        public Account Account { get; set; }
    }
}
