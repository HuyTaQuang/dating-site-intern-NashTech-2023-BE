using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingApp.DAL.Models
{
    [Table("message")]
    public class Message
    {
        [Column("message_id")]
        public int MessageId { get; set; }
        [Column("user_id_1")]
        public int UserId1 { get; set; }
        [Column("user_id_2")]
        public int UserId2 { get; set; }
        [Column("message_text")]
        public string? MessageText { get; set; }
        [Column("message_time")]
        public string? MessageTime { get; set; } 
        [Column("modified_by")]
        public string? ModifiedBy { get; set; }
        [Column("modified_date")]
        public DateTime ModifiedDate { get; set; }
        [Column("created_by")]
        public string? CreatedBy { get; set; }
        [Column("created_date")]
        public DateTime CreatedDate { get; set; } = DateTime.Now; //Khi tạo mặc định sẽ lấy time hiện tại
        [Column("is_deleted")]
        public bool IsDeleted { get; set; } = false; //Khi tạo giá trị mặc định sẽ là fall
    }
}
