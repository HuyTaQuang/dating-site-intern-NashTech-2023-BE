

using System.ComponentModel.DataAnnotations.Schema;

namespace DatingApp.DAL.Models
{
    [Table("match")]
    public class Match
    {
        [Column("match_id")]
        public int MatchId { get; set; }
        [Column("user_id_1")]
        public int UserId1 { get; set; }
        [Column("user_id_2")]
        public int UserId2 { get; set; }
    }
}
