using System;

namespace MySkyNetApp.Domain.Models
{
    public class Autor
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Email { get; set; }

        public string Descricao { get; set; }

        public DateTime InstanteCriacao { get; set; } = DateTime.Now;
    }
}
