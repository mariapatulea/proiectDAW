using System.Threading.Tasks;

namespace proiectDAW.Repositories
{
    public interface IRepositoryWrapper
    {
        IAuthorRepository Author { get; }
        Task SaveAsync();
    }
}
