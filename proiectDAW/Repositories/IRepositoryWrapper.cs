using System.Threading.Tasks;

namespace proiectDAW.Repositories
{
    public interface IRepositoryWrapper
    {
        IAuthorRepository Author { get; }
        IEditorRepository Editor { get; }
        IBookRepository Book { get; }
        IUserRepository User { get; }
        ISessionTokenRepository SessionToken { get; }
        Task SaveAsync();
    }
}
