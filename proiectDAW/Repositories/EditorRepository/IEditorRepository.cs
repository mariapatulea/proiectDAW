using proiectDAW.Models.Entities;
using System.Threading.Tasks;

namespace proiectDAW.Repositories
{
    public interface IEditorRepository : IGenericRepository<Editor>
    {
        // metode custom pentru Editor
        Task<Editor> GetEditorByPublishingHouse(string publishingHouse);
        Task<Editor> GetEditorByIdWithAuthor(int id);
        Task<Editor> UpdateEditorPublishingHouse(int id, string newPublishingHouse);
    }
}
