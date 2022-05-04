using System;
using MySkyNetApp.Application.Common.Mappings;
using MySkyNetApp.Domain.Models;

namespace MySkyNetApp.Application.CreateAutor
{
    public class CreateAutorResult : IMapFrom<Autor>
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Email { get; set; }

        public string Descricao { get; set; }

        public DateTime InstanteCriacao { get; set; }
    }
}
