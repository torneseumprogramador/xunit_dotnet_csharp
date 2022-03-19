using Escola.Entidades;
using Escola.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace XUnitTestEscola.Repositorios.Mock
{
    class AlunoRepositorioMock : IRepositorio
    {
        public int Quantidade()
        {
            return this.Todos().Count;
        }

        private List<Aluno> alunos = new List<Aluno>();

        public List<Aluno> Todos()
        {
            return alunos;
        }

        public void Salvar(Aluno aluno)
        {
            var alunos = this.Todos();
            alunos.Add(aluno);
        }
    }
}
