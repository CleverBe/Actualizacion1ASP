using System.ComponentModel.DataAnnotations;

namespace ApiCompetencia.Models
{
    public class Productos_Bd
    {
        [Key]
        public int id { get; set; }
        public string nombre { get; set; }
        public decimal costo { get; set; }
        public decimal precio { get; set; }
        public string caracteristicas { get; set; }
        public int stock { get; set; }
        public string marca { get; set; }
        public int categoria_id { get; set; }
    }
}
