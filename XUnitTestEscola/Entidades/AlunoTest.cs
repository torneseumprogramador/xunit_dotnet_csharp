using Escola.Entidades;
using Escola.Exceptions;
using System;
using Xunit;
using Xunit.Abstractions;
using XUnitTestEscola.Repositorios.Mock;

namespace XUnitTestEscola
{
    public class AlunoTest : IDisposable
    {
        public ITestOutputHelper Output { get; }
        public AlunoTest(ITestOutputHelper output)
        {
            Output = output;
            Output.WriteLine("Inicio do meu teste, metodo executado primeiro.");
        }

        [Trait("Instancias", "AlunoTeste")]
        [Fact(DisplayName = "Testando a criacao de uma instancia")]
        public void Test1()
        {
            var aluno = new Aluno();
            aluno.Nome = "Danilo";

            Assert.Equal("Danilo", aluno.Nome);
        }

        [Trait("Instancias", "Aluno")]
        [Fact(DisplayName = "Utilizando um teste de falha")]
        public void Test2()
        {
            //arrange
            var aluno = new Aluno();

            //act
            aluno.Nome = "Danilo";

            //assert
            Assert.True(aluno.Nome != "Juis");
        }

        [Trait("Instancias", "Erro")]
        [Fact(DisplayName = "Um deste de validação de erros")]
        public void TratandoErro()
        {
            //arrange
            var numero = 0;

            //act
            Assert.Throws<DivideByZeroException>(
                //assert
                () => numero / 0
            );
        }

        [Trait("Instancias", "Usuario")]
        [Fact(DisplayName = "Um teste de validacao")]
        public void ValidaNome()
        {
            //arrange
            var aluno = new Aluno();
            aluno.Nome = "";

            //act
            Assert.Throws<AlunoValidateErro>(
                //assert
                () => aluno.Validar()
            );
        }

        [Fact]
        public void TestandoPrivado()
        {
            //arrange
            var aluno = new AlunoMock();

            //act //assert
            Assert.Contains("Número", aluno.Numero(1));
        }

        [Theory]
        [InlineData("Lana Santos", "852.849.190-09")]
        [InlineData("Denilson Santos", "936.299.900-53")]
        [InlineData("Maria Felix", "936.299.900-53")]
        [InlineData("Maria Felix", "93629990053")]
        public void ValidarCPFValidos(string nome, string cpf)
        {
            //Arrange
            Aluno aluno = new Aluno();
            aluno.Nome = nome;
            aluno.Cpf = cpf;

            //Act
            bool validado = aluno.ValidarCPF();

            //Assert
            Assert.True(validado);
        }

        [Theory]
        [InlineData("Maria Felix", "000.000.000-00")]
        [InlineData("Maria Felix", "111.000.000-00")]
        [InlineData("Maria Felix", "111.333.113-43")]
        [InlineData("Maria Felix", "111.333")]
        public void ValidarCPFInvalidos(string nome, string cpf)
        {
            //Arrange
            Aluno aluno = new Aluno();
            aluno.Nome = nome;
            aluno.Cpf = cpf;

            //Act
            bool validado = aluno.ValidarCPF();

            //Assert
            Assert.True(!validado);
        }

        [Trait("Instancias", "Aluno")]
        [Fact(DisplayName = "Teste que eu ignorei", Skip = "Ignorando teste pois faremos este depois")]
        public void Test3()
        {
            var aluno = new Aluno();
            aluno.Nome = "Danilo";

            Assert.Equal("dfsdsdsd", aluno.Nome);
        }

        public void Dispose()
        {
            Output.WriteLine("Está é a acao final do meu teste");
        }
    }
}
