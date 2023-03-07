using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingApp.DAL.Models
{
    [Table("hobby")]
    public class Hobby
    {
        [Column("hobby_id")]
        public int HobbyId { get; set; }
        [Column("hobby_name")]
        public string HobbyName { get; set; }
        public string? ModifiedBy { get; set; }
        [Column("modified_date")]
        public DateTime? ModifiedDate { get; set; }
        [Column("created_by")]
        public string? CreatedBy { get; set; }
        [Column("created_date")]
        public DateTime CreatedDate { get; set; } = DateTime.Now; //Khi tạo mặc định sẽ lấy time hiện tại
        [Column("is_deleted")]
        public bool IsDeleted { get; set; } = false; //Khi tạo giá trị mặc định sẽ là fall

        #region Lk bang khoa ngoai
        public ICollection<UserHoppy>? UserHoppies { get; set; }
        #endregion

    }
}
