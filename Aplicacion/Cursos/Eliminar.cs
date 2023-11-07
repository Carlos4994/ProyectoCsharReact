using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;


using MediatR;
using Dominio;
using Microsoft.EntityFrameworkCore.Internal;
using Persistencia;

namespace Aplicacion.Cursos
{
    public class Eliminar
    {
        public class Ejecutar: IRequest{
            public int Id { get; set; }
            
        }

        public class Manejador: IRequestHandler<Ejecutar>{
            private readonly CursosOnlineContex _context;

            public Manejador (CursosOnlineContex context){
                _context=context;
            }
            public async Task<Unit> Handle(Ejecutar request, CancellationToken cancellationToken)
            {
                var curso = await _context.Curso.FindAsync(request.Id);
                if (curso== null)
                {
                  throw new Exception(" No se puede eliminar este curso no encontrdo");  
                }
                _context.Remove(curso);
                var resultado = await _context.SaveChangesAsync();
                if (resultado>0)
                {
                   return Unit.Value;
                }
                throw new Exception("No se gurdaron los cambios");

            }




        }

    }
}
