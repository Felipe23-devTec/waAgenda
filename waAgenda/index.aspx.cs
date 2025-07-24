using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace waAgenda
{
    public partial class index : System.Web.UI.Page
    {
        public bool usaCaf = false;
        bool desabilitar = true;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Chamar o método para preencher a GridView com dados
                if (Session["Username"] != null)
                {
                    string username = Session["Username"].ToString();
                    //lblWelcome.Text = "Bem-vindo, " + username + "!";
                }

                string teste = "";

                if (teste.Length == 0)
                {
                    Console.WriteLine("Verdadeiro");
                }
                if (string.IsNullOrWhiteSpace(teste))
                {
                    Console.WriteLine("Verdadeiro");
                }
                int numRows = 3;
                int numCells = 2;

                // Sample data for demonstration
                string[] names = { "John", "Jane", "Mike" };
                int[] ages = { 30, 25, 42 };

                for (int j = 0; j < numRows; j++)
                {
                    TableRow row = new TableRow();

                    // Add header cells for the first row (j == 0)
                    if (j == 0)
                    {
                        TableCell headerCell1 = new TableCell();
                        headerCell1.Text = "Name";
                        row.Cells.Add(headerCell1);

                        TableCell headerCell2 = new TableCell();
                        headerCell2.Text = "Age";
                        row.Cells.Add(headerCell2);
                    }
                    // Add data cells for subsequent rows (j > 0)
                    else
                    {
                        TableCell dataCell1 = new TableCell();
                        dataCell1.Text = names[j - 1];  // Access data from the names array, adjust index for header row
                        row.Cells.Add(dataCell1);

                        TableCell dataCell2 = new TableCell();
                        dataCell2.Text = ages[j - 1].ToString(); // Convert integer age to string, adjust index for header row
                        row.Cells.Add(dataCell2);
                    }

                    Table1.Rows.Add(row);
                }

                // Criar uma tabela de dados (DataTable)
                DataTable dt = new DataTable();
                dt.Columns.Add("Pais");
                dt.Columns.Add("Estado");
                dt.Columns.Add("Capital");
                dt.Columns.Add("Ações");



                // Criar instância do Random para gerar dados aleatórios
                Random rnd = new Random();

                // Simular alguns dados
                string[] paises = { "Brasil", "Argentina", "Chile", "Uruguai", "Paraguai" };
                string[] estados = { "Estado A", "Estado B", "Estado C", "Estado D", "Estado E" };
                string[] capitais = { "Capital X", "Capital Y", "Capital Z", "Capital W", "Capital Q" };

                // Preencher a DataTable com dados aleatórios
                for (int i = 0; i < 5; i++)
                {
                    DataRow dr = dt.NewRow();
                    dr["Pais"] = paises[rnd.Next(paises.Length)];
                    dr["Estado"] = estados[rnd.Next(estados.Length)];
                    dr["Capital"] = capitais[rnd.Next(capitais.Length)];
                    dt.Rows.Add(dr);
                }

                // Vincular a DataTable ao GridView
                GridView1.DataSource = dt;
                GridView1.DataBind();
                ConfigurarColunaDocumento(usaCaf);
                CarregarDados();
                


            }
            //else
            //{
            //    // Registrar comandos de botão para validação
            //    foreach (GridViewRow row in GridView1.Rows)
            //    {
            //        Button btnAcao = (Button)row.FindControl("btnAcao");
            //        if (btnAcao != null)
            //        {
            //            ClientScript.RegisterForEventValidation(btnAcao.UniqueID);
            //        }
            //    }
            //}
            
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            
            if (desabilitar)
            {
                TextBox txtDinamico = new TextBox();
                txtDinamico.ID = "Text1";

                // Adiciona o TextBox como filho do <td>
                tdDinamico.Controls.Add(txtDinamico);
            }
            else
            {
                TextBox txtOriginal = new TextBox();
                txtOriginal.ID = "Text1";

                // Adiciona o TextBox como filho do <td>
                tdDinamico2.Controls.Add(txtOriginal);
            }
            
        }
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Button btnAcao = (Button)e.Row.FindControl("btnAcao");
                if (btnAcao != null)
                {
                    ClientScript.RegisterForEventValidation(btnAcao.UniqueID, btnAcao.CommandArgument);
                }
            }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "CustomCommand")
            {
                // Obter o índice da linha do botão clicado
                int index = Convert.ToInt32(e.CommandArgument);
                // Obter a linha do GridView
                GridViewRow row = GridView1.Rows[index];

                // Obter os valores das células da linha
                string pais = row.Cells[0].Text;
                string estado = row.Cells[1].Text;
                string capital = row.Cells[2].Text;

                // Implementar a lógica do botão
                // Exemplo: exibir uma mensagem
                string message = $"Você clicou no botão da linha com País: {pais}, Estado: {estado}, Capital: {capital}.";
                // Exibir a mensagem (usar um controle Label ou JavaScript para exibir a mensagem)
                // Exemplo com Label:
                // Label1.Text = message;
                // Exemplo com JavaScript:
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + message + "');", true);
            }
        }

        protected void btnPesquisar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(search.Text))
            {
                var pesquisa = search.Text;
            }
        }

        //private void CarregarGrid()
        //{
        //    DataTable dt = new DataTable();
        //    dt.Columns.Add("TpPessoaBenfcrio");
        //    dt.Columns.Add("CNPJ_CPFBenfcrio");
        //    dt.Columns.Add("DAPBenfcrio");
        //    dt.Columns.Add("CAFBenfcrio");
        //    dt.Columns.Add("TpBenfcrioCOR");

        //    // Simulando dados (substitua por dados reais de banco, se necessário)
        //    dt.Rows.Add("Física", "123.456.789-00", "DAP001", "CAF001", "Titular");
        //    dt.Rows.Add("Jurídica", "12.345.678/0001-00", "DAP002", "CAF002", "Dependente");

        //    gvBeneficiarios.DataSource = dt;
        //    gvBeneficiarios.DataBind();
        //}
        //protected void gvBeneficiarios_RowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //    if (e.Row.RowType == DataControlRowType.DataRow)
        //    {
        //        string tipoPessoa = DataBinder.Eval(e.Row.DataItem, "TpPessoaBenfcrio").ToString();
        //        string valorDocumento = !usaCaf
        //            ? DataBinder.Eval(e.Row.DataItem, "DAPBenfcrio").ToString()
        //            : DataBinder.Eval(e.Row.DataItem, "CAFBenfcrio").ToString();

        //        Label lblDocumento = (Label)e.Row.FindControl("lblDocumento");
        //        if (lblDocumento != null)
        //        {
        //            lblDocumento.Text = valorDocumento;
        //        }
        //    }
        //    else if (e.Row.RowType == DataControlRowType.Header)
        //    {
        //        // Define o cabeçalho com base no primeiro item da fonte de dados
        //        DataTable dt = gvBeneficiarios.DataSource as DataTable;
        //        if (dt != null && dt.Rows.Count > 0)
        //        {
        //            string tipoPessoa = dt.Rows[0]["TpPessoaBenfcrio"].ToString();
        //            string headerText = !usaCaf? "DAP Beneficiário" : "CAF Beneficiário";

        //            Label lblHeader = (Label)e.Row.FindControl("lblHeaderDoc");
        //            if (lblHeader != null)
        //            {
        //                lblHeader.Text = headerText;
        //            }
        //        }
        //    }
        //}


        private void ConfigurarColunaDocumento(bool usaCaf)
        {
            // Índice da coluna que será alterada dinamicamente (3ª coluna declarada = índice 2)
            BoundField colunaDocumento = gvBeneficiario.Columns[2] as BoundField;

            if (colunaDocumento != null)
            {
                colunaDocumento.DataField = usaCaf ? "CAFBenfcrio" : "DAPBenfcrio";
                colunaDocumento.HeaderText = usaCaf ? "CAF Beneficiário" : "DAP Beneficiário";
            }
        }
        private void CarregarDados()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("TpPessoaBenfcrio");
            dt.Columns.Add("CNPJ_CPFBenfcrio");
            if (usaCaf)
                dt.Columns.Add("CAFBenfcrio");
            else
                dt.Columns.Add("DAPBenfcrio");
            dt.Columns.Add("TpBenfcrioCOR");

            if (usaCaf)
            {
                dt.Rows.Add("Física", "123.456.789-00", "CAF001", "Titular");
                dt.Rows.Add("Jurídica", "12.345.678/0001-00", "CAF002", "Dependente");
            }
            else
            {
                dt.Rows.Add("Física", "123.456.789-00", "DAP001", "Titular");
                dt.Rows.Add("Jurídica", "12.345.678/0001-00", "DAP002", "Dependente");
            }

            gvBeneficiario.DataSource = dt;
            gvBeneficiario.DataBind();
        }
        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            if (desabilitar)
            {
                // Agora podemos recuperar o valor
                TextBox txt = (TextBox)tdDinamico.FindControl("Text1");
                if (txt != null)
                {
                    string valor = txt.Text;
                    // Use o valor conforme precisar
                }
            }
            else
            {
                TextBox txt = (TextBox)tdDinamico2.FindControl("Text1");
                if (txt != null)
                {
                    string valor = txt.Text;
                    // Use o valor conforme precisar
                }
            }
            

        }
    }
}