using Dominio;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistencia;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.Cursos
{
    public class Consulta
    {
        public class ListarCursos: IRequest<List<Curso>>
        {

        }

        public class Manejador : IRequestHandler<ListarCursos, List<Curso>>
        {
            private readonly CursosOnlineContex _context;
            public Manejador(CursosOnlineContex context) { 
            _context = context;
            }
            public async Task<List<Curso>> Handle(ListarCursos request, CancellationToken cancellationToken)
            {
                
              var cursos =await _context.Curso.ToListAsync();
                return cursos;
            }
        }
    }
}
