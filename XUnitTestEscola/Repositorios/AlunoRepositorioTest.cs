using Escola.Entidades;
using Escola.Repositorios;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using XUnitTestEscola.Repositorios.Mock;

namespace XUnitTestEscola.Repositorios
{
    public class AlunoRepositorioTest
    {
        [Fact]
        public void Test1()
        {
            //Arrange
            //var repo = new AlunoRepositorio(new AlunoRepositorioJson());
            //var repo = new AlunoRepositorio(new AlunoRepositorioSql());
            var repo = new AlunoRepositorio(new AlunoRepositorioMock());
            var aluno = new Aluno()
            {
                Id = 1,
                Matricula = "003",
                Nome = "Gil",
                Notas = new List<double>() { 6,8,8 }
            };

            //Act
            repo.Salvar(aluno);

            //Assert
            Assert.Equal(1, repo.Quantidade());
            Assert.Equal("Gil", repo.Todos()[0].Nome);
        }
    }
}
