
using System.ComponentModel.DataAnnotations.Schema;

namespace DatingApp.DAL.Models
{
    [Table("image")]
    public class Image
    {
        [Column("image_id")]
        public int ImageId { get; set; }
        [Column("image_name")]
        public string ImageName { get; set; }
       
        [Column("image_url")]
        public string ImageUrl { get; set; }
        public string? ModifiedBy { get; set; }
        [Column("modified_date")]
        public DateTime? ModifiedDate { get; set; }
        [Column("created_by")]
        public string? CreatedBy { get; set; }
        [Column("created_date")]
        public DateTime CreatedDate { get; set; } = DateTime.Now; //Khi tạo mặc định sẽ lấy time hiện tại
        [Column("is_deleted")]
        public bool IsDeleted { get; set; } = false; //Khi tạo giá trị mặc định sẽ là fall

        public User User { get; set; }
    }
}
