using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace CodeFirstASPCore6.Models
{
    public class StudentContext : DbContext
    {
        public StudentContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Student> Students { get; set; }
    }
}
