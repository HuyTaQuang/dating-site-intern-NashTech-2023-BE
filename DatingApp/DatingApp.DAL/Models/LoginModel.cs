using System.ComponentModel.DataAnnotations;

namespace DatingApp.DAL.Models
{
    /// <summary>
    /// Để người dùng gửi lên
    /// </summary>
    public class LoginModel
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }

    }
}
