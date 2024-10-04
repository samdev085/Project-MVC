using ProjectMVCv._2.Models;

namespace ProjectMVCv._2.Repository
{
    public interface INoticeRepository
    {
        public Task<List<Notice>> ListNotices();
        bool CreateNotice(Notice notice);
        Notice GetNoticeById(int id);
        bool UpdateNotice(Notice notice);
        bool DeleteNotice(int id);
    }
}
