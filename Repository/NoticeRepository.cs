using ProjectMVCv._2.Data;
using ProjectMVCv._2.Models;

namespace ProjectMVCv._2.Repository
{
    public class NoticeRepository : INoticeRepository
    {

        private readonly Context _optionsbuilder;

        public NoticeRepository(Context optionsbuilder)
        {
            _optionsbuilder = optionsbuilder;
        }
        public bool CreateNotice(Notice notice)
        {
            _optionsbuilder.Notices.Add(notice);
            _optionsbuilder.SaveChanges();
            return true;
        }

        public bool DeleteNotice(int id)
        {
            bool result = false;

            Notice notice = _optionsbuilder.Notices.Find(id);
            if (notice != null)
            {
                _optionsbuilder.Notices.Remove(notice);
                _optionsbuilder.SaveChanges();

                result = true;
                return result;
            }

            return result;
        }

        public Notice GetNoticeById(int id)
        {
            Notice result = _optionsbuilder.Notices.FirstOrDefault(notice => notice.Id == id);
            return result;
        }

        public async Task<List<Notice>> ListNotices()
        {
            List<Notice> list = _optionsbuilder.Notices.ToList();
            return list;
        }

        public bool UpdateNotice(Notice notice)
        {
            _optionsbuilder.Notices.Update(notice);
            _optionsbuilder.SaveChanges();
            return true;
        }
    }
}
