using EducationalBlog.Data.Models;
using EducationalBlog.Data.Models.UpdateModels;

namespace EducationalBlog.Data.Repositories
{
    public interface ITagRepository
    {
        public Task CreateTag(Tag tag);
        public Task UpdateTag(Tag tag, UpdateTagModel updateTag);
        public Task DeleteTag(Tag tag);
        public Task<Tag> GetTagById(Guid id);
        public Task<Tag[]> GetTagArray();
    }
}
