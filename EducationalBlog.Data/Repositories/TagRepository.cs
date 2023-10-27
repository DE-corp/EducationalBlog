using EducationalBlog.Data.Context;
using EducationalBlog.Data.Models;
using EducationalBlog.Data.Models.UpdateModels;
using Microsoft.EntityFrameworkCore;

namespace EducationalBlog.Data.Repositories
{
    public class TagRepository : ITagRepository
    {

        public BlogContext _context;
        public TagRepository(BlogContext context)
        {
            _context = context;
        }

        public async Task CreateTag(Tag tag)
        {
            var entry = _context.Entry(tag);
            if (entry.State == EntityState.Detached)
                _context.AddAsync(entry);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteTag(Tag tag)
        {
            var entry = _context.Entry(tag);
            if (entry.State == EntityState.Detached)
                _context.Remove(entry);

            await _context.SaveChangesAsync();
        }

        public async Task<Tag[]> GetTagArray()
        {
            return await _context.Tags
                .ToArrayAsync();
        }

        public async Task<Tag> GetTagById(Guid id)
        {
            return await _context.Tags
                .Where(t => t.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task UpdateTag(Tag tag, UpdateTagModel updateTag)
        {
            if (!string.IsNullOrEmpty(updateTag.NewTag))
                tag.Value = updateTag.NewTag;

            var entry = _context.Entry(tag);
            if (entry.State == EntityState.Detached)
                _context.Update(entry);

            await _context.SaveChangesAsync();
        }
    }
}
