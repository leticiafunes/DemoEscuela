using Microsoft.EntityFrameworkCore;
using WebAPIEscuela.Data;
using WebAPIEscuela.Models;

namespace WebAPIEscuela.Data
{
    public class DBEscuelaAPIContext : DbContext
    {

        //Siempre declaramos el constructor
        public DBEscuelaAPIContext(DbContextOptions<DBEscuelaAPIContext> options) : base(options) {
        }
        
        public DbSet <Alumno> Alumnos { get; set; }
        public DbSet<Profesor> Profesores { get; set; }

        public DbSet<Especialidad> Especialidades { get; set; }

    }
}
