namespace ProjectMVCv._2.Models
{
    public class CreateNoticeTagModel
    {
        public int NoticeId { get; set; }
        public int TagId { get; set; } 

        public List<Notice> Notices;

        public List<Tag> Tags;
    }
}
