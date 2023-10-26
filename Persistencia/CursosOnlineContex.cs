using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Dominio;

namespace Persistencia
{
    public class CursosOnlineContex:DbContext
    {
        public CursosOnlineContex(DbContextOptions options): base(options){

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.Entity<CursoInstructor>().HasKey(ci => (ci.InstructorId, ci.CursoId));
        }

        public DbSet<Comentario> Comentario { get; set; }
        public DbSet<Curso> Curso{get;set;}
        
    }
}
