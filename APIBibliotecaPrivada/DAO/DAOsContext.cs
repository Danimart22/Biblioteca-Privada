using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using APIBibliotecaPrivada.Entidades;
namespace APIBibliotecaPrivada.DAO
{
    public class DAOsContext : DbContext
    {
        public DbSet<Libro> Cursos { get; set; }
        
        public DAOsContext(DbContextOptions<DAOsContext> options) : base(options) { }
    }
}
