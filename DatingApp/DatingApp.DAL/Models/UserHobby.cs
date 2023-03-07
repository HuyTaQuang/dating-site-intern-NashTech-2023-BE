using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingApp.DAL.Models
{
    [Table("user_interest")]
    public class UserHoppy
    {
        [Column("user_id")]
        public int UserId { get; set; }
        [Column("hobby_id")]
        public int HobbyId { get; set; }
        [Column("created_date")]
        public DateTime CreatedDate { get; set; } = DateTime.Now; //Khi tạo mặc định sẽ lấy time hiện tại
        [Column("created_by")]
        public string? CreatedBy { get; set; }
        [Column("modified_by")]
        public string? ModifiedBy { get; set; }
        [Column("modified_date")]
        public DateTime ModifiedDate { get; set; }
        [Column("is_deleted")]
        public bool IsDeleted { get; set; } = false; //Khi tạo giá trị mặc định sẽ là fall

        public User? User { get; set; }
        public Hobby? Hobby { get; set; }
    }
}
