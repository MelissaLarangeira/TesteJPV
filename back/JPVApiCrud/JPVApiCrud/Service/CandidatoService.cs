using JPVApiCrud.Model;
using JPVApiCrud.Repository;
using JPVApiCrud.Validation;

namespace JPVApiCrud.Service
{
    public class CandidatoService : ICandidatoService
    {
        //regra de negocio
        private readonly ICandidadoRepository _repository;
       
        public CandidatoService(ICandidadoRepository repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<Candidato>> BuscarLista()
        {
            return await _repository.BuscarLista();
        }
        public async Task<Candidato?> BuscaPorId(int id)
        {
          return await _repository.BuscarPorID(id);                        
        }
        public async Task AdicionarCandidato(Candidato candidato)
        {            
            await Validation.Validation.ValidateInputs(candidato);
            await _repository.AdicionarCandidato(candidato);
        }
        public async Task<bool> AtualizarCandidato(int id, Candidato candidato)
        {
            await Validation.Validation.ValidateInputs(candidato);
            return await _repository.AtualizarCandidato(id, candidato);
        }
        public async Task<bool> ExcluirCandidato(int id)
        {
           return await _repository.ExcluirCandidato(id);
        }
    }
}
