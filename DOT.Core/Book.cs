using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOT.Core {
    public class Book {
        public Guid ID { get; set; }

        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }
        public virtual Author Author { get; private set; }

        [Required(ErrorMessage = "Author is required")]
        public Guid AuthorID { get; set; }
    }
}
