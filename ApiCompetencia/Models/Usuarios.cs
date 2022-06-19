
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiCompetencia.Models
{
    [Table("usuarios")]
    public class Usuarios
    {

        [Key]
        public int id { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string username { get; set; }
        public string password { get; set; }

    }
}
