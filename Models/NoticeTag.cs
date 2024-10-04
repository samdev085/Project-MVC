using Azure;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectMVCv._2.Models
{
    public class NoticeTag
    {
        [ForeignKey("Id")]
        [Column("Id")]
        public int Id { get; set; }

        [Column("NoticeId")]
        public required int Notice { get; set; }

        [Column("TagId")]
        public required int Tag { get; set; }
    }
}
