using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectMVCv._2.Models
{
    public class Notice
    {
        [ForeignKey("Id")]
        [Column("Id")]
        public int Id { get; set; }

        [Column("Title")]
        public required string Title { get; set; }

        [Column("Text")]
        public required string Text { get; set; }

        [Column("UserId")]
        public required int User { get; set; }
    }
}
