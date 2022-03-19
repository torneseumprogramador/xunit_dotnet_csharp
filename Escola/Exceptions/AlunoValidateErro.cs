using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escola.Exceptions
{
    public class AlunoValidateErro : Exception
    {
        public AlunoValidateErro(string mensagem) : base(mensagem) { }
    }
}
