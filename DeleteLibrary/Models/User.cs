using System.ComponentModel.DataAnnotations;

namespace DeleteLibrary.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }
        public bool IsDeleted { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
        public User()
        {
            IsDeleted = false;
            RoleId = 2;
        }
    }
}