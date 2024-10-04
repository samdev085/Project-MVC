using ProjectMVCv._2.Data;
using ProjectMVCv._2.Models;

namespace ProjectMVCv._2.Repository
{
    public class NoticeTagRepository : INoticeTagRepository
    {
        private readonly Context _optionsbuilder;

        public NoticeTagRepository(Context optionsbuilder)
        {
            _optionsbuilder = optionsbuilder;
        }

        public bool CreateNoticeTagConfirm(NoticeTag noticeTag)
        {
            var result = _optionsbuilder.NoticesTags.Add(noticeTag);
            _optionsbuilder.SaveChanges();
            return true;
        }

        public List<NoticeTag> GetAll()
        {
            List<NoticeTag> list = _optionsbuilder.NoticesTags.ToList();
            if (list.Count != 0) 
            {
                return list;
            }

            return list;
        }
    }
}
