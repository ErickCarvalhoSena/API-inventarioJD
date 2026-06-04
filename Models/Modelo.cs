

namespace OficinaJD.API.Models
{
    public class Modelo
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string? CodigoJD { get; set; }

        public string? Tipo { get; set; }

        public List<PecaModelo> PecaModelos { get; set; } = new ();
    }
}