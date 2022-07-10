using System;
namespace NetEFCore.Core.Models
{
    public class PessoaJuridica : PessoaBase
    {
        public string Cnpj { get; set; }
        public DateTime RegisterDate { get; set; }
    }
}

