using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Librarys.Models
{
    public class Shelfs
    {
        public Shelfs()
        { 
            BooksList = new List<Books>();
        }

        [Key, Display(Name = "מספר מדף")]
        public int Id { get; set; }

        public int Height { get; set; }

        public LibraryCategory? Category { get; set; }

        [NotMapped]
        public int libId { get; set; }

        public List<Books>? BooksList { get; set; }

        
    }
}
