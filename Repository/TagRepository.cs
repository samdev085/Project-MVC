using Microsoft.AspNetCore.Mvc;
using ProjectMVCv._2.Data;
using ProjectMVCv._2.Models;

namespace ProjectMVCv._2.Repository
{
    public class TagRepository : ITagRepository
    {
        private readonly Context _optionsbuilder;

        public TagRepository(Context optionsbuilder)
        {
            _optionsbuilder = optionsbuilder;
        }

        public async Task<Tag> CreateNewTag(Tag tag)
        {
            await _optionsbuilder.Tags.AddAsync(tag);
            await _optionsbuilder.SaveChangesAsync();

            return tag;
        }

        public bool EditTagConfirm(Tag tag)
        {           
            _optionsbuilder.Tags.Update(tag);
            _optionsbuilder.SaveChanges();
            return true;           
        }

        public bool DeleteTag(int id)
        {
            bool result = false;

            Tag user = _optionsbuilder.Tags.Find(id);
            if (user != null)
            {
                _optionsbuilder.Tags.Remove(user);
                _optionsbuilder.SaveChanges();

                result = true;
                return result;
            }

            return result;

        }

        public Tag GetTagById(int id)
        {
            Tag tag = _optionsbuilder.Tags.FirstOrDefault(x => x.Id == id);

            return tag;
        }

        public async Task <List<Tag>> ListTags()
        {          
                List<Tag> tagsList =  _optionsbuilder.Tags.ToList();               

                return tagsList;            
        }
    }
}
