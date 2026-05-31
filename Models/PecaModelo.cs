
namespace OficinaJD.API.Models
{
    public class PecaModelo
    {
        public int PecaId { get; set; }
        public Peca Peca { get; set; } = null;
        public int ModeloId { get; set; }
        public Modelo Modelo { get; set; } = null;
    }
}