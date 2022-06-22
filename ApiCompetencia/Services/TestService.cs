using ApiCompetencia.Models;

namespace ApiCompetencia.Services
{
    public class TestService : ITestService
    {
        private List<Categoria_BD> _categoria = new List<Categoria_BD>()
        {
            new Categoria_BD(){id = 2, nombre = "luis", estado = "activo"},
        };

        public IEnumerable<Categoria_BD> Get() => _categoria;

        public Categoria_BD? Get(int id) => _categoria.FirstOrDefault(d => d.id == id);
    }
}
