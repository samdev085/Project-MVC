using Microsoft.AspNetCore.Mvc;
using ProjectMVCv._2.Models;

namespace ProjectMVCv._2.Repository
{
    public interface ITagRepository
    {
        public Task<List<Tag>> ListTags();
        Task<Tag> CreateNewTag(Tag tag);
        public bool EditTagConfirm(Tag tag);
        public bool DeleteTag(int id);
        public Tag GetTagById(int id);
    }
}
