using Dominio;
using MediatR;
using Microsoft.EntityFrameworkCore.Internal;
using Persistencia;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.Cursos
{
    public class Nuevo
    {
        public class Ejecutar : IRequest
        {
            public string Titulo { get; set; }
            public string Descripcion { get; set; }
            public DateTime FechaPublicacion { get; set; }
        }
        public class Manejador : IRequestHandler<Ejecutar>
        {
            private readonly CursosOnlineContex _context;
            public Manejador(CursosOnlineContex context)
            {
            _context = context;
            }

            public async Task<Unit> Handle(Ejecutar request, CancellationToken cancellationToken)
            {
                var curso = new Curso
                {
                    Titulo = request.Titulo,
                    Descripcion = request.Descripcion,
                    FechaPublicacion = request.FechaPublicacion,
                };
                _context.Curso.Add(curso);
                // si devuelve cero no hizotransccion 
                var valor = await _context.SaveChangesAsync();
                if (valor>0)
                {
                    return Unit.Value; 
                }

                throw new Exception("No se puedo insetar el curso");

            }
        }
    }
}
