using Microsoft.EntityFrameworkCore;
using proiectDAW.Models;
using proiectDAW.Models.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace proiectDAW.Repositories
{
    public class EditorRepository : GenericRepository<Editor>, IEditorRepository
    {
        public EditorRepository(AppDbContext context) : base(context) { }

        public async Task<Editor> GetEditorByIdWithAuthor(int id)
        {
            return await _context.Editors.Include(editor => editor.Author).Where(editor => editor.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Editor> GetEditorByPublishingHouse(string publishingHouse)
        {
            return await _context.Editors.Where(editor => editor.PublishingHouse == publishingHouse).FirstOrDefaultAsync();
        }

        public async Task<Editor> UpdateEditorPublishingHouse(int id, string newPublishingHouse)
        {
            _context.Editors.Where(editor => editor.Id == id).ToList().ForEach(editor => editor.PublishingHouse = newPublishingHouse);
            return await _context.Editors.Where(editor => editor.Id == id).FirstOrDefaultAsync();
        }
    }
}
