using Microsoft.EntityFrameworkCore;
using Librarys.Models;

namespace Librarys.DAL
{
    public class DataLayer : DbContext
    {
        public DataLayer(string ConnectionString) : base(GetOptions(ConnectionString))
        {
            Database.EnsureCreated();
            Seed();
        }

        private void Seed()
        {
            if (LibraryCategory.Count() > 0)
            {
                return;
            }
            LibraryCategory libraryCategory = new LibraryCategory();

            libraryCategory.Category = "חסידות";

            LibraryCategory.Add(libraryCategory);

            SaveChanges();
        }






        //private void Seed()
        //{
        //    LibraryCategory libraryCategory;
        //    if (!LibraryCategory.Any())
        //    {
        //        libraryCategory = new LibraryCategory { Category = "חסידות" };
        //        LibraryCategory.Add(libraryCategory);
        //    }
        //    else
        //    {
        //        libraryCategory = LibraryCategory.First();
        //    }
        //    return libraryCategory;


        //}

        //private LibraryCategory AddDefaultTeammate()
        //{
        //    //
        //    Shelfs shelfs = AddNewBook();

        //    if (!Shelfs.Any())
        //    {
        //        libraryCategory.AddShelf(14);
        //    }
        //    Shelfs shelfs;
        //    if (!Books.Any())
        //    {
        //        shelfs.AddBook();
        //    }
        //    SaveChanges();
        //}

        //public void AddNewBook(int booksHeight, string booksName)
        //{
        //    Books newBook = new Books { Height = booksHeight, Name = booksName, Shelfs = this };
        //}


        private static DbContextOptions GetOptions(string connectionString)
        {
            return new DbContextOptionsBuilder()
                .UseSqlServer(connectionString)
                .Options;
        }


        public DbSet<LibraryCategory> LibraryCategory { get; set; }

        public DbSet<Shelfs> Shelfs { get; set; }

        public DbSet<Books> Books { get; set; }

    }
}
