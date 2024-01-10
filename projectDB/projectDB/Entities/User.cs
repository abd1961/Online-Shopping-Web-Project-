using System.ComponentModel.DataAnnotations;

namespace projectDB.Entities
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        
        [Required(ErrorMessage = "{0} is required")]
        [StringLength(50,MinimumLength = 5,ErrorMessage = "username should be minimum 3 characters and maximum 50 charachters")]
        public string UserName { get; set; }

        public string? Usermail { get; set; }
        [Required]


        [StringLength(100,MinimumLength = 8)]
        public string Password { get; set; }

        [Required]
        public string Role { get; set; }


       
    }
}
