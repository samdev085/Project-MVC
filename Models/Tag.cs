using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectMVCv._2.Models
{
    public class Tag
    {
        [ForeignKey("Id")]
        [Column("Id")]
        public int Id { get; set; }

        [Column("Description")]
        public required string Description { get; set; }
    }
}
