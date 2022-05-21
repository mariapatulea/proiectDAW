using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using proiectDAW.Models.Entities;

namespace proiectDAW.Models
{
    public class AppDbContext : IdentityDbContext<User, Role, int, IdentityUserClaim<int>, UserRole, IdentityUserLogin<int>, IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Editor> Editors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<SessionToken> SessionTokens { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // one to many (Author - Book)
            builder.Entity<Author>()
                .HasMany(author => author.PublishedBooks)
                .WithOne(book => book.Author);

            // one to one (Author - Editor)
            builder.Entity<Author>()
                .HasOne(author => author.Editor)
                .WithOne(editor => editor.Author);

            // many to many (Reader - Book, prin tabelul ReaderBook)
            builder.Entity<ReaderBook>().HasKey(readerBook => new { readerBook.ReaderId, readerBook.BookId });  // setam cheia primara
            // a tabelului de legatura ReaderBook ca fiind un obiect cu 2 proprietati -> ReaderId si BookId
            builder.Entity<ReaderBook>()  // legatura one to many dintre ReaderBook si Reader
                .HasOne(readerBook => readerBook.Reader)
                .WithMany(reader => reader.ReaderBooks)
                .HasForeignKey(readerBook => readerBook.ReaderId);
            builder.Entity<ReaderBook>()  // legatura one to many dintre ReaderBook si Book
                .HasOne(readerBook => readerBook.Book)
                .WithMany(book => book.ReaderBooks)
                .HasForeignKey(readerBook => readerBook.BookId);

            // relatia de many to many dintre role si user
            builder.Entity<UserRole>(userRole =>
            {
                userRole.HasKey(userRole => new { userRole.UserId, userRole.RoleId });
                userRole.HasOne(userRole => userRole.Role).WithMany(role => role.UserRoles).HasForeignKey(userRole => userRole.RoleId);
                userRole.HasOne(userRole => userRole.User).WithMany(user => user.UserRoles).HasForeignKey(userRole => userRole.UserId);
            });
        }
    }
}
