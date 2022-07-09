using System;
using NetEFCore.Core.Interfaces;

namespace NetEFCore.Core.Models
{
    public class PessoaBase : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}

