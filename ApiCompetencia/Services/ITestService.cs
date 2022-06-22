using ApiCompetencia.Models;

namespace ApiCompetencia.Services
{
    public interface ITestService
    {
        public IEnumerable<Categoria_BD> Get();
        public Categoria_BD? Get(int id);
    }
}
