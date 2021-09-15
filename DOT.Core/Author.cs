using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DOT.Core {
    public class Author {
        public Guid ID { get; set;}

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
    }
}
