
namespace OficinaJD.API.Models
{
    public class Peca
    {
        public int Id { get; set; }
        public string Codigo { get; set; } = string.Empty;
        public string? Descricao { get; set; }
        public int Quantidade { get; set; }
        public string? Localizacao { get; set; }

        public List<PecaModelo> PecaModelos { get; set; } = new();
    }
}