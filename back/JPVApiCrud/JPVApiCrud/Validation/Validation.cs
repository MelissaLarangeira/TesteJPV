using JPVApiCrud.Model;
using JPVApiCrud.Repository;

namespace JPVApiCrud.Validation
{       public class Validation
        {
        public static async Task ValidateInputs(Candidato candidato)
        {      
            if (!String.IsNullOrWhiteSpace(candidato.CdCpf)) await ValidateCpf(candidato.CdCpf);
            await validateDate(candidato.DtNascCandidato);
        }
        public static async Task<bool> ValidateCpf(string candidatoCPF)
        {
            string[] cpfsInvalidos = new string[] { "00000000000", "11111111111", "22222222222", "33333333333", "44444444444", "55555555555", "66666666666", "77777777777", "88888888888", "99999999999" };

            if (!cpfsInvalidos.Contains(candidatoCPF))
            {
                int cont = 10;
                int aux = 0;
                int i;

                if (long.TryParse(candidatoCPF, out long _))
                {
                    for (i = 0; i <= 8; i++)
                    {
                        aux += int.Parse(candidatoCPF[i].ToString()) * cont;
                        cont--;
                    }

                    aux *= 10;
                    aux %= 11;

                    if (aux == 10) aux = 0;

                    if (aux == int.Parse(candidatoCPF[9].ToString()))
                    {
                        cont = 11;
                        aux = 0;

                        for (i = 0; i <= 9; i++)
                        {
                            aux += int.Parse(candidatoCPF[i].ToString()) * cont;
                            cont--;
                        }

                        aux *= 10;
                        aux %= 11;

                        if (aux == 10) aux = 0;
                        if (aux == int.Parse(candidatoCPF[10].ToString()))
                        {
                            return true;
                        }
                    }
                }
            }
            throw new InputValidationException("CPF inválido.");
        }

        public static async Task<bool> validateDate(DateTime dtnascimento)
        {
            if (dtnascimento == null) { throw new InputValidationException("Necessario preencher data de nascimento"); }
           
            if (dtnascimento >= DateTime.Now)
            {
                throw new InputValidationException("Data Invalida");

            }
              return true;
        }
    }
}
