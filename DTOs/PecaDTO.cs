using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OficinaJD.API.DTOs
{
    public class PecaDTO
    {
        public int Id { get; set; }
        public string Codigo { get; set; } = string.Empty;
        public string? Descricao { get; set; }
        public int Quantidade { get; set; }
        public string? Localizacao { get; set; }
        public List<string> Modelos { get; set; } = new();
    }

    public class CriarPecaDTO
    {
        public string Codigo { get; set; } = string.Empty;
        
        public string? Descricao { get; set; }

        public int Quantidade { get; set; }
        
        public string? Localizacao { get; set; }
        
        public List<int> ModeloIds { get; set; } = new();
    }
}