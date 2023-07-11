using Microsoft.Ajax.Utilities;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JPV
{
    public partial class _Default : Page
    {
        private readonly ILogger<_Default> _Logger;
        protected async void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                await GetCandidatosFromDatabase();

            }
        }
        protected void ExibirErro(string mensagem)
        {
            string script = $"<script>alert('{mensagem}');</script>";
            ClientScript.RegisterStartupScript(GetType(), "ExibirErro", script);
        }
        private async Task GetCandidatosFromDatabase()
        {
            using (var httpClient = new HttpClient())
            {
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri("http://localhost:5031/api/Candidato/")
                };
                var response = await httpClient.SendAsync(request);

                string content = await response.Content.ReadAsStringAsync();

                IEnumerable<Candidato> candidatos = JsonConvert.DeserializeObject<IEnumerable<Candidato>>(content);

                GridViewCandidatos.DataSource = candidatos;
                GridViewCandidatos.DataBind();
            }
        }
        private async Task GetCandidatPorId(int id)
        {

            using (var httpClient = new HttpClient())
            {
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri("http://localhost:5031/api/Candidato/" + id)
                };
                var response = await httpClient.SendAsync(request);

                string content = await response.Content.ReadAsStringAsync();

                var result = response.StatusCode;

                if (response.IsSuccessStatusCode)
                {
                    IEnumerable<Candidato> candidatos = JsonConvert.DeserializeObject<IEnumerable<Candidato>>(content);

                    GridViewCandidatos.DataSource = candidatos;
                    GridViewCandidatos.DataBind();
                }
                else
                {
                    string mensagem = "ID não existe ou ja foi excluido";
                    ExibirErro(mensagem);
                }

            }
        }
        private async Task DeleteCandidatoById(int id)
        {
            using (var httpClient = new HttpClient())
            {
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Delete,
                    RequestUri = new Uri("http://localhost:5031/api/Candidato/" + id)
                };
                var response = await httpClient.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    GetCandidatosFromDatabase();
                
                }
                else {
                    //ExibirErro("Candidato não existe ou ja foi excluido");
                    string script = @"<script type='text/javascript'>alert('Mensagem de erro.');</script>";

                    ScriptManager.RegisterStartupScript(this, GetType(), "ErroPopup", script, false);
                                     
                }


            }
        }


        private async Task CreateCandidato(Candidato candidatos)
        {
            using (var httpClient = new HttpClient())
            {
                var uri = "http://localhost:5031/api/Candidato";

                var objeto = new
                {
                    NmCandidato = candidatos.NmCandidato,
                    DtNascCandidato = candidatos.DtNascCandidato,
                    vlRendaCandidato = candidatos.VlRendaCandidato,
                    CdCpf = candidatos.CdCpf
                };

                string json = JsonConvert.SerializeObject(objeto);

                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await httpClient.PostAsync(uri, content);

                if (response.IsSuccessStatusCode)
                {
                    GetCandidatosFromDatabase();
                }
                else
                {
                    string mensagem = "Favor validar os dados fornecidos";
                    ExibirErro(mensagem);
                }

            }

           

        }
        private async Task UpdateCandidato(int id, Candidato candidatos)
        {
            using (var httpClient = new HttpClient())
            {
                var uri = "http://localhost:5031/api/Candidato/" + id;

                var objeto = new
                {
                    nome = candidatos.NmCandidato,
                    dtnac = candidatos.DtNascCandidato,
                    vlrRenda = candidatos.VlRendaCandidato,
                    cpf = candidatos.CdCandidato
                };
                if (txtCPF.Text.Length == 11)
                {

                    string json = JsonConvert.SerializeObject(objeto);

                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    var response = await httpClient.PutAsync(uri, content);

                    // Verifica se a solicitação foi bem-sucedida
                    if (response.IsSuccessStatusCode)
                    {
                        GetCandidatosFromDatabase();
                    }
                    else
                    {
                        ExibirErro("Favor validar se todos os campos foram preenchidos");
                    }

                }
                else if (txtCPF.Text.Length < 11)
                    ExibirErro("CPF esta com menos caracteres que o padrão");
                else
                    ExibirErro("CPF esta com mais caracteres que o padrão");


            }
        }
        protected async void btnConsultar_Click(object sender, EventArgs e)
        {
            if (txtId.Text == "" || txtId.Text == null)
            {
                await GetCandidatosFromDatabase();
            }
            else
                await GetCandidatPorId(int.Parse(txtId.Text));
        }
        protected async void btnAlterar_Click(object sender, EventArgs e)
        {
            Candidato candidatos = new Candidato();
            int id = int.Parse(txtId.Text);

            if (txtDtnasc.Text == string.Empty || txtCPF.Text == string.Empty || txtNome.Text == string.Empty)
            {
                ExibirErro("Favor validar os campos obrigatorios");
            }
            else

            candidatos.NmCandidato = txtNome.Text;
            candidatos.DtNascCandidato = DateTime.Parse(txtDtnasc.Text);
            candidatos.VlRendaCandidato = Decimal.Parse(txtvlrRenda.Text);
            candidatos.CdCpf = txtCPF.Text;

            await UpdateCandidato(id, candidatos);

            txtCPF.Text = string.Empty;
            txtvlrRenda.Text = string.Empty;
            txtNome.Text = string.Empty;
            txtId.Text = string.Empty;
            txtDtnasc.Text = string.Empty;
        }
        protected async void btnIncluir_Click(object sender, EventArgs e)
        {
            Candidato candidatos = new Candidato();

            if (String.IsNullOrWhiteSpace(txtDtnasc.Text)|| String.IsNullOrWhiteSpace(txtCPF.Text)  || String.IsNullOrWhiteSpace(txtNome.Text))
            {
                ExibirErro("Favor validar os campos obrigatorios");
                return;
            }

            if (!Decimal.TryParse(txtvlrRenda.Text,out _))
            {
                ExibirErro("Campo somente numerico");
                return;
            }

            var x = txtDtnasc.Text;


            candidatos.NmCandidato = txtNome.Text;
            candidatos.DtNascCandidato = DateTime.Parse(txtDtnasc.Text);
            candidatos.VlRendaCandidato = !String.IsNullOrWhiteSpace(txtvlrRenda.Text)? Decimal.Parse(txtvlrRenda.Text): 0;
            candidatos.CdCpf = txtCPF.Text;

            await CreateCandidato(candidatos);

            txtCPF.Text = string.Empty;
            txtvlrRenda.Text = string.Empty;
            txtNome.Text = string.Empty;
            txtId.Text = string.Empty;
            txtDtnasc.Text = string.Empty;
        }
        protected async void btnExcluir_Click(object sender, EventArgs e)
        {
            if (txtId.Text == "" || txtId.Text == null)
            {
               ExibirErro("Id precisa ser preenchido");
            }
            else
                await DeleteCandidatoById(int.Parse(txtId.Text));

             txtId.Text = string.Empty;
           
        }
    }
}






