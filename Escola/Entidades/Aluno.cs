using Escola.Exceptions;
using System.Collections.Generic;

namespace Escola.Entidades
{
    public class Aluno
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Matricula { get; set; }
        public List<double> Notas { get; set; }
        public string Cpf { get; set; }

        public double Media()
        {
            double somaNotas = 0;
            foreach (var nota in this.Notas)
                somaNotas += nota;

            return somaNotas / this.Notas.Count;
        }

        public string Situacao()
        {
            return (this.Media() > 6 ? "Aprovado" : "Reprovado");
        }

        public string NotasFormadata()
        {
            return string.Join(",", this.Notas);
        }

        public bool ValidarCPF()
        {
            string valor = this.Cpf.Replace(".", "");
            valor = valor.Replace("-", "");

            if (valor == "00000000000") return false;
            if (valor == "11111111111") return false;
            if (valor == "22222222222") return false;
            if (valor == "33333333333") return false;
            if (valor == "44444444444") return false;
            if (valor == "55555555555") return false;
            if (valor == "66666666666") return false;
            if (valor == "77777777777") return false;
            if (valor == "88888888888") return false;
            if (valor == "99999999999") return false;

            if (valor.Length != 11)
                return false;

            bool igual = true;
            for (int i = 1; i < 11 && igual; i++)
                if (valor[i] != valor[0])
                    igual = false;

            if (igual || valor == "12345678909")
                return false;

            int[] numeros = new int[11];

            for (int i = 0; i < 11; i++)
                numeros[i] = int.Parse(
                  valor[i].ToString());
            int soma = 0;

            for (int i = 0; i < 9; i++)
                soma += (10 - i) * numeros[i];

            int resultado = soma % 11;

            if (resultado == 1 || resultado == 0)
            {
                if (numeros[9] != 0)
                    return false;
            }
            else if (numeros[9] != 11 - resultado)
                return false;

            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += (11 - i) * numeros[i];

            resultado = soma % 11;

            if (resultado == 1 || resultado == 0)
            {
                if (numeros[10] != 0)
                    return false;
            }
            else
                if (numeros[10] != 11 - resultado)
                return false;

            return true;
        }

        public void Validar()
        {
            throw new AlunoValidateErro("Ainda nao fizemos");
        }

        protected string numero(int x)
        {
            return "Número: " + (x + 1);
        }
    }
}
