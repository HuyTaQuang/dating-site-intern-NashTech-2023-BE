using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingApp.DAL.Models
{
    [Table("like")]
    public class Like
    {
        public int LikeId { get; set; }
        [Column("user_like_id")]
        public string? UserLikeId { get; set; }
        [Column("user_liked_id")]
        public string? UserLikedId { get; set; }
        [Column("created_date")]
        public DateTime CreatedDate { get; set; } = DateTime.Now; //Khi tạo mặc định sẽ lấy time hiện tại
        [Column("modified_by")]
        public string? ModifiedBy { get; set; }
        [Column("modified_date")]
        public DateTime ModifiedDate { get; set; } 
        [Column("is_deleted")]
        public bool IsDeleted { get; set; } = false; //Khi tạo giá trị mặc định sẽ là fall

        #region Lk bang khoa ngoai
        public User User { get; set; }
        #endregion
    }
}
