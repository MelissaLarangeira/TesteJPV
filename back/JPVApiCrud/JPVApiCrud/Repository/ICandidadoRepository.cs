using JPVApiCrud.Model;
using Microsoft.AspNetCore.Mvc;

namespace JPVApiCrud.Repository
{
    public interface ICandidadoRepository
    {
        public Task<Candidato?> BuscarPorID(int id);
        public Task AdicionarCandidato([FromBody] Candidato candidato);
        public Task<bool> AtualizarCandidato(int id, Candidato candidato);
        public Task<bool> ExcluirCandidato(int id);
        public Task<IEnumerable<Candidato>> BuscarLista();
    }
}
