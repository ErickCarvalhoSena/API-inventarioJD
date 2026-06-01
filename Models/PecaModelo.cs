
namespace OficinaJD.API.Models
{
    public class PecaModelo
    {
        public int PecaId { get; set; }
        public Peca? Peca { get; set; }
        public int ModeloId { get; set; }
        public Modelo? Modelo { get; set; } 
    }
}