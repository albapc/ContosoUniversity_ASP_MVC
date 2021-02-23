using ContosoUniversity.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace ContosoUniversity.DAL
{
    public class SchoolContext : DbContext
    {
        /*
         * Nombre de la cadena de conexión (que se agregará al archivo Web. config). Si no especifica una cadena de conexión o el nombre
         * de una explícitamente, Entity Framework supone que el nombre de la cadena de conexión es el mismo que el nombre de la clase
         */
        public SchoolContext() : base("SchoolContext")
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Course> Courses { get; set; }

        // Impide que los nombres de tabla se confirmen. De no ser así, por ejemplo quedaría Students en vez de Student
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}