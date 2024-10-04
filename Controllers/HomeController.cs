using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ProjectMVCv._2.Filters;
using ProjectMVCv._2.Helpers;
using ProjectMVCv._2.Models;
using ProjectMVCv._2.Repository;

using System.Diagnostics;

namespace ProjectMVCv._2.Controllers
{
    [ForLoggedUser]
    public class HomeController : Controller
    {

        private readonly IUserRepository _IUserRepository;
        private readonly ITagRepository _ITagRepository;
        private readonly INoticeRepository _INoticeRepository;
        private readonly INoticeTagRepository _INoticeTagRepository;
        private readonly IUserSession _IUserSession;
        

        public HomeController(IUserRepository userRepository, IUserSession iUserSession, 
            ITagRepository tagRepository, INoticeRepository noticeRepository, INoticeTagRepository noticeTagRepository)
        {
            _IUserRepository = userRepository;
            _IUserSession = iUserSession;
            _ITagRepository = tagRepository;
            _INoticeRepository = noticeRepository;
            _INoticeTagRepository = noticeTagRepository;
        }

        public IActionResult Index()
        {
            var user = _IUserSession.GetUserSession();
            if (user == null) 
            {
                return RedirectToAction("Index","Login");
            }
            
            return View(user);
        }


 
        public async Task<ActionResult<List<Tag>>> Tag()
        {
           List<Tag> tagList = await _ITagRepository.ListTags(); 
            return View(tagList);
        }
        public IActionResult CreateTag()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateNewTag(Tag tag)
        {
            await _ITagRepository.CreateNewTag(tag);
            return RedirectToAction("Tag", "Home");
        }
        public ActionResult EditTag(int id)
        {
            Tag tag = _ITagRepository.GetTagById(id);
            
            return View(tag);
        }
        [HttpPost]
        public ActionResult EditTagConfirm(Tag tag)
        {
            bool result = _ITagRepository.EditTagConfirm(tag);
            if (result == true) 
            {
                return RedirectToAction("Tag", "Home");
            }

            return View("Index", "Home");
        }
        public IActionResult DeleteTag(int id)
        {
            Tag user = _ITagRepository.GetTagById(id);

            return View(user);
        }
        public IActionResult DeleteConfirm(int id)
        {
            bool result =  _ITagRepository.DeleteTag(id);
            if (result == true)
            {
                return RedirectToAction("Tag", "Home");
            }

            return RedirectToAction("Index", "Home");
        }




        public async Task<ActionResult<List<Notice>>> Notice()
        {
            List<Notice> list =  await _INoticeRepository.ListNotices();
            return View(list);
        }
        public IActionResult CreateNotice()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateNoticeConfirm(Notice notice)
        {
            User user = _IUserSession.GetUserSession();
            if (user != null)
            {
                notice.User = user.Id;
                if (ModelState.IsValid)
                {
                    bool result = _INoticeRepository.CreateNotice(notice);
                    if (result == true)
                        return RedirectToAction("Notice", "Home");
                }
            }
            return RedirectToAction("Index", "Home");
        }
        public IActionResult EditNotice(Notice notice)
        {
            Notice result = _INoticeRepository.GetNoticeById(notice.Id);
            return View(result);
        }
        public IActionResult EditNoticeConfirm(Notice notice)
        {
            Notice result = _INoticeRepository.GetNoticeById(notice.Id);
            if (result != null)
            {
                User user = _IUserSession.GetUserSession();
                result.Title = notice.Title;
                result.Text = notice.Text;
                result.User = user.Id;
                bool check = _INoticeRepository.UpdateNotice(result);
                if (check == true) return RedirectToAction("Notice", "Home");
            }

            return RedirectToAction("Index", "Home");    
            
        }       
        public IActionResult DeleteNotice(int id)
        {
            Notice notice = _INoticeRepository.GetNoticeById(id);

            return View(notice);
        }
        public IActionResult DeleteNoticeConfirm(int id)
        {
            Notice result = _INoticeRepository.GetNoticeById(id);
            if (result != null) 
            {
                bool check =_INoticeRepository.DeleteNotice(result.Id);
                if (check == true) return RedirectToAction("Notice", "Home");
            }

            return RedirectToAction("Index", "Home");
        }



        public async Task<ActionResult<List<NoticeTag>>> NoticeTag()
        {
            List<NoticeTag> list = _INoticeTagRepository.GetAll();
            return View(list);
        }
        public async Task<IActionResult> CreateNoticeTag()
        {
            List<Notice> noticeList = await _INoticeRepository.ListNotices();
            List<Tag> tagList = await _ITagRepository.ListTags();

            CreateNoticeTagModel createNoticeTagModel = new CreateNoticeTagModel();
            createNoticeTagModel.Notices = noticeList;
            createNoticeTagModel.Tags = tagList;

            return View(createNoticeTagModel);
        }
        [HttpPost]
        public IActionResult CreateNoticeTagConfirm(CreateNoticeTagModel createNoticeTagModel) 
        {
            int noticeId = createNoticeTagModel.NoticeId;
            int tagId = createNoticeTagModel.TagId;
            NoticeTag newNoticeTag = new NoticeTag() 
            { 
                Notice = noticeId,
                Tag = tagId            
            };
            var result =_INoticeTagRepository.CreateNoticeTagConfirm(newNoticeTag);
            if (result == true)
            {
                return RedirectToAction("NoticeTag", "Home");
            }

            return RedirectToAction("Index", "Home");
            
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
