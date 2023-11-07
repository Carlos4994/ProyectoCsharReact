using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
///
using MediatR;
using Dominio;
using Microsoft.EntityFrameworkCore.Internal;
using Persistencia;


namespace Aplicacion.Cursos
{
    public class Editar
    {
        public class Ejecutar: IRequest{
            public int CursoId { get; set; }
            public string Titulo { get; set; }
            public string Descripcion { get; set; }
            public DateTime? FechaPublicacion { get; set; } 
        }

        public class Manejador: IRequestHandler<Ejecutar>{
            private readonly CursosOnlineContex _context;

            public Manejador (CursosOnlineContex context){
                _context=context;
            }
            public async Task<Unit> Handle(Ejecutar request, CancellationToken cancellationToken)
            {
                var curso = await _context.Curso.FindAsync(request.CursoId);
                if (curso== null)
                {
                  throw new Exception("Curso no encontrdo");  
                }
                curso.Titulo = request.Titulo ?? curso.Titulo;
                curso.Descripcion= request.Descripcion ?? curso.Descripcion;
                curso.FechaPublicacion= request.FechaPublicacion ?? curso.FechaPublicacion;
                var resultado = await _context.SaveChangesAsync();
                if (resultado>0)
                {
                   return Unit.Value;
                }
                throw new Exception("No se gurdaron los cmbios");

            }




        }



    }
}
