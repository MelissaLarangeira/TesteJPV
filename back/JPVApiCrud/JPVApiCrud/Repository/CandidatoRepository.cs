using JPVApiCrud.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JPVApiCrud.Repository
{
    public class CandidatoRepository  :ICandidadoRepository 
    {
        private readonly JpvContext _context;
        public CandidatoRepository(JpvContext context)
        {
            _context = context;                        
        }        
        public async Task<IEnumerable<Candidato>> BuscarLista()
        {
               return await _context.Candidatos.ToListAsync();
        }
        public async Task<Candidato?> BuscarPorID(int id) 
        {
            try
            {
                return await  _context.Candidatos.FirstOrDefaultAsync(c => c.CdCandidato == id);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        
        }
        public async Task AdicionarCandidato( Candidato candidato)
        {
            try
            {
             await   _context.Candidatos.AddAsync(candidato);
             await   _context.SaveChangesAsync();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }   
        
                       
        }
        public async Task<bool> AtualizarCandidato(int id, Candidato candidatoAtu)
        {
            var candidato = _context.Candidatos.FirstOrDefault(c => c.CdCandidato == id);
            
            if (candidato == null)
            {
                return false;
            }

            candidato.NmCandidato = candidatoAtu.NmCandidato;
            candidato.DtNascCandidato = candidatoAtu.DtNascCandidato;
            candidato.VlRendaCandidato = candidatoAtu.VlRendaCandidato;
            candidato.CdCpf = candidatoAtu.CdCpf;

           _context.Candidatos.Update(candidato);
           await _context.SaveChangesAsync();

            return true;
        }
        public async Task<bool> ExcluirCandidato(int id)
        {
           var  candidato = _context.Candidatos.FirstOrDefault(c => c.CdCandidato == id);
            if (candidato == null)           
            {
                return false;
            }

            _context.Candidatos.Remove(candidato);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
