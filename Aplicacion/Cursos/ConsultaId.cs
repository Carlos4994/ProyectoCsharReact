﻿using Dominio;
using MediatR;
using Persistencia;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.Cursos
{
    public class ConsultaId
    {
        public class CursoUnico: IRequest<Curso>
        {
            public int Id { get; set; }
        }
        public class Manejador : IRequestHandler<CursoUnico, Curso>
        {
            private readonly CursosOnlineContex _context;
            public Manejador(CursosOnlineContex context)
            {
                _context = context;
            }

            public async Task<Curso> Handle(CursoUnico request, CancellationToken cancellationToken)
            {
                var curso=await _context.Curso.FindAsync(request.Id);
                return curso;
            }
        }
    }
}
