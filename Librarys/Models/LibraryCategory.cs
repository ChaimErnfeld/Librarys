using System.ComponentModel.DataAnnotations;

namespace Librarys.Models
{
    public class LibraryCategory
    {
        public LibraryCategory()
        {
            ShelfsList = new List<Shelfs>();
        }
        [Key]
        public int Id { get; set; }

        public string Category { get; set; }

        public List<Shelfs>? ShelfsList { get; set; }

        //public void AddShelf(int shelfHeight)
        //{
        //    Shelfs newShelf = new Shelfs{ Height = shelfHeight, Category = this };
        //}



        //public int SetShelf
        //{
        //    //get { return null; }
        //    set
        //    {
                

        //        AddShelf(SetShelf());

        //    }
        //}



        public void AddShelf(int height)
        {

            Shelfs slf = new()
            {
                Height = height,
                Category = this
            };

            ShelfsList.Add(slf);

        }
    }

}
