using Escola.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace XUnitTestEscola.Repositorios.Mock
{
    class AlunoMock : Aluno
    {
        public string Numero(int x)
        {
            return this.numero(x);
        }
    }
}
