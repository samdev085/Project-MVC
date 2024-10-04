using ProjectMVCv._2.Models;

namespace ProjectMVCv._2.Repository
{
    public interface INoticeTagRepository
    {
        List<NoticeTag> GetAll();
        public bool CreateNoticeTagConfirm(NoticeTag noticeTag);
    }
}
