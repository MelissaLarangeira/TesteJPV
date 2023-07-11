using JPVApiCrud.Model;
using Microsoft.AspNetCore.Mvc;

namespace JPVApiCrud.Service
{
    public interface ICandidatoService
    {
        public Task<IEnumerable<Candidato>> BuscarLista();
        public Task<Candidato?> BuscaPorId(int id);
        public Task AdicionarCandidato([FromBody] Candidato candidato);
        public Task<bool> AtualizarCandidato(int id, Candidato candidato);
        public Task<bool> ExcluirCandidato(int id);      
    }
}
