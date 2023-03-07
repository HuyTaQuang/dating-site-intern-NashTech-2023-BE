using System.ComponentModel.DataAnnotations.Schema;

namespace DatingApp.DAL.Models
{
    /// <summary>
    /// Lớp người dùng
    /// </summary>
    [Table("user")]
    public class User
    {
        [Column("user_id")]
        public int UserId { get; set; }
      
        [Column("username")]
        public string Username { get; set; }

        [Column("password")]
        public string Password { get; set; }
     
        [Column("full_name")]
        public string FullName { get; set; }
        [Column("email")]
        public string? Email { get; set; }
       
        [Column("gender")]
        public int Gender { get; set; }
        [Column("address")]
        public string? Address { get; set; }
        [Column("avatar")]
        public string? Avatar { get; set; }
        [Column("date_of_birth")]
        public DateTime Date_Of_Birth { get; set; }
        [Column("description")]
        public string? Description { get; set; }
        [Column("modified_by")]
        public string? ModifiedBy { get; set; }
        [Column("modified_date")]
        public DateTime ModifiedDate { get; set; }
        [Column("created_by")]
        public string? CreatedBy { get; set; }
        [Column("created_date")]
        public DateTime CreatedDate { get; set; } = DateTime.Now; //Khi tạo mặc định sẽ lấy time hiện tại
        [Column("is_deleted")]
        public bool IsDeleted { get; set; } = false; //Khi tạo giá trị mặc định sẽ là fall}

        #region Lk bang khoa ngoai 
        public ICollection<Image>? Images { get; set; }
        public ICollection<UserHoppy>? UserHoppies { get; set; }
        public ICollection<Like>? Likes { get; set; }
        #endregion
    }
}
