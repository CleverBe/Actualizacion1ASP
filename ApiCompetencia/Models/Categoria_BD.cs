using System.ComponentModel.DataAnnotations;

namespace ApiCompetencia.Models
{
    public class Categoria_BD
    {
        [Key]
        public int id { get; set; }
        public string nombre { get; set; }
        public string estado { get; set; }
    }
}
