using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Librarys.Models
{
    public class Books
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public int Height { get; set; }

        public Shelfs? Shelfs { get; set; }

        [NotMapped]
        public int slfId { get; set; }
    }
}
