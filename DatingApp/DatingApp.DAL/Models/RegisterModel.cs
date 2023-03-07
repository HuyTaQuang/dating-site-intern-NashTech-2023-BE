using System.ComponentModel.DataAnnotations;

namespace DatingApp.DAL.Models
{
    public class RegisterModel
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string? Email { get; set; }
        public int? Gender { get; set; }
        public string? Address { get; set; }
        public string? Avatar { get; set; }
        public DateTime Date_Of_Birth { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now; //Khi tạo mặc định sẽ lấy time hiện tại
        public bool IsDeleted { get; set; } = false; //Khi tạo giá trị mặc định sẽ là fall}

    }
}
