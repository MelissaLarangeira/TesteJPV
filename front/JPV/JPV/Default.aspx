<%@ Page Title="Candidato JPV" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="JPV._Default" Async="true" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>
        <style>
            /* Estilos gerais */
            body {
                background-color: #fef6e4;
                font-family: Arial, sans-serif;
                text-align: center;
            }

            .container {
                max-width: 800px;
                margin: 0 auto;
                padding: 20px;
            }

            /* Estilos para a seção de consulta de candidato */
            .GetCandidatoPorIDFront {
                margin-bottom: 20px;
                background-color: #fff4d4;
                border: 1px solid #ecc500;
                padding: 20px;
                border-radius: 5px;
                display: inline-block;
                text-align: left;
            }

                .GetCandidatoPorIDFront label {
                    display: block;
                    font-weight: bold;
                    margin-bottom: 5px;
                }

                .GetCandidatoPorIDFront input[type="text"],
                .GetCandidatoPorIDFront input[type="date"] {
                    padding: 5px;
                    border: 1px solid #ccc;
                    border-radius: 3px;
                    outline: none;
                }

            /* Estilos para os botões de ação */
            Estilos para a tabela de candidatos
            .DivGrid {
                margin-top: 20px;
            }

            .DivGrid table {
                width: 100%;
                border-collapse: collapse;
            }
        </style>
        <div class="GetCandidatoPorIDFront">

            <label for="campo">ID Candidato:
            <a href="#" class="info-icon" title="Campo ID somente utilizado para consultas">
                <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-info-circle" viewBox="0 0 16 16">
                    <path d="M8 15A7 7 0 1 1 8 1a7 7 0 0 1 0 14zm0 1A8 8 0 1 0 8 0a8 8 0 0 0 0 16z" />
                    <path d="m8.93 6.588-2.29.287-.082.38.45.083c.294.07.352.176.288.469l-.738 3.468c-.194.897.105 1.319.808 1.319.545 0 1.178-.252 1.465-.598l.088-.416c-.2.176-.492.246-.686.246-.275 0-.375-.193-.304-.533L8.93 6.588zM9 4.5a1 1 0 1 1-2 0 1 1 0 0 1 2 0z" />
                </svg>
            </a>
                </label>
            <%--<i class="bi bi-info-circle" title="Campo ID somente utilizado para consultas"></i>--%>
            <asp:TextBox runat="server" CssClass="form-control" ID="txtId"></asp:TextBox>

            <label for="campo">*Nome:</label>
            <asp:TextBox runat="server" CssClass="form-control" autocomplete="off" ID="txtNome"></asp:TextBox>
            <label for="campo">*Data Nascimento:</label>
            <asp:TextBox runat="server" CssClass="form-control" ID="txtDtnasc" TextMode="Date" MaxLength="10" placeholder="dd/mm/aaaa"></asp:TextBox>
            <label for="campo">Renda:</label>
            <asp:TextBox runat="server" CssClass="form-control" ID="txtvlrRenda"></asp:TextBox>
            <label for="campo">*CPF:</label>
            <asp:TextBox runat="server" CssClass="form-control" ID="txtCPF"></asp:TextBox>
        </div>

        <br>

        <div>
            <asp:Button runat="server" ID="btnConsultar" CssClass="btn btn-outline-primary" ToolTip="Consultar Candidato" OnClick="btnConsultar_Click" Text="Consultar" />
            <asp:Button runat="server" ID="btnAlterar" CssClass="btn btn-outline-warning" ToolTip="Alterar Candidato" OnClick="btnAlterar_Click" Text="Alterar" />
            <asp:Button runat="server" ID="btnIncluir" CssClass="btn btn-outline-success" ToolTip="Incluir Candidato" OnClick="btnIncluir_Click" Text="Incluir" />
            <asp:Button runat="server" ID="btnExcluir" CssClass="btn btn-outline-danger" ToolTip="Excluir Candidato" OnClick="btnExcluir_Click" Text="Excluir" />
        </div>

        <br>

        <div class="DivGrid">
            <asp:GridView ID="GridViewCandidatos" runat="server" AutoGenerateColumns="False" EmptyDataText="VAZIO" CssClass="table table-bordered table-striped">
                <Columns>
                    <asp:BoundField DataField="CdCandidato" HeaderText="ID" />
                    <asp:BoundField DataField="NmCandidato" HeaderText="Nome" />
                    <asp:BoundField DataField="DtNascCandidato" HeaderText="Data de Nascimento" DataFormatString="{0:dd/MM/yyyy}" />
                    <asp:BoundField DataField="VlRendaCandidato" HeaderText="Renda" DataFormatString="{0:C}" />
                    <asp:BoundField DataField="CdCpf" HeaderText="CPF" />
                </Columns>
                <HeaderStyle BackColor="#ff9900" Font-Bold="true" BorderStyle="Solid" BorderWidth="1px" />
                <RowStyle BackColor="Wheat" BorderColor="Black" />
            </asp:GridView>

        </div>
    </main>

    <script>
        function exibirErro(mensagem) {
            alert(mensagem);
        }
    </script>

</asp:Content>

