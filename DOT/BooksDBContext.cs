using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using DOT.Core;
using Microsoft.EntityFrameworkCore;

namespace DOT {
    public class BooksDBContext : DbContext {
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }

        public BooksDBContext(DbContextOptions<BooksDBContext> options) : base(options) {

        }
    }
}
