using System;
namespace NetEFCore.Core.Models
{
    public class PessoaFisica : PessoaBase
    {
        public string Cpf { get; set; }
        public DateTime BirthDate { get; set; }
    }
}

