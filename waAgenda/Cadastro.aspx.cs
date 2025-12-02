using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Schema;
using System.Xml;
using System.Xml.Serialization;
using waAgenda.classes;
using static waAgenda.WebForm1;
using System.Data.SqlTypes;

namespace waAgenda
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        [Serializable]
        public class Cliente
        {
            public string CpfCnpj { get; set; }
            public string TipoPessoa { get; set; }

        }
        private List<Cliente> Clientes
        {
            get
            {
                if (ViewState["Clientes"] == null)
                    ViewState.Add("Clientes", new List<Cliente>());
                return (List<Cliente>)ViewState["Clientes"];
            }
            set
            {
                if (ViewState["Clientes"] == null)
                    ViewState.Add("Clientes", new List<Cliente>());
                ViewState["Clientes"] = value;
            }
        }

        //Criando view state para operadores, exemplo de uso de Dual list

        protected Dictionary<string, string> OperadoresDisponiveis
        {
            get
            {
                if (ViewState["OperadoresDisponiveis"] == null)
                    ViewState["OperadoresDisponiveis"] = new Dictionary<string, string>();
                return (Dictionary<string, string>)ViewState["OperadoresDisponiveis"];
            }
            set
            {
                ViewState["OperadoresDisponiveis"] = value;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidarCampo();
            if (!IsPostBack)
            {
                CarregarCombos();
                gvCooperado.DataSource = new List<object>();
                gvCooperado.DataBind();

                lstOrigem.Items.Add(new ListItem("0001 -tes", "0001"));
                lstOrigem.Items.Add(new ListItem("Item 2", "2"));
                lstOrigem.Items.Add(new ListItem("Item 3", "3"));

                CarregarOperadores();

            }
            
        }

        protected void txtTpPessCoop_TextChanged(object sender, EventArgs e)
        {
            ValidarCampo();
        }
        protected void cboTpPessCoop_TextChanged(object sender, EventArgs e)
        {
            string tipoSelecionado = ddlTipoPessoa.SelectedValue;
        }

        protected void btnInserir_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {

                //gerar Xml e validar com XSD

                Pessoa pessoa = new Pessoa();
                pessoa.Nome = "Felipe";
                pessoa.IdadeNova = 25;
                string xml = string.Empty;
                XmlSerializer serializer = new XmlSerializer(typeof(Pessoa));
                using (var sw = new StringWriter())
                {
                    serializer.Serialize(sw, pessoa);
                    xml = sw.ToString();
                }
                string xsdPath = "C:\\xsd\\cliente.xsd";

                // 🔹 Valida o XML em memória
                ValidarXml(xml, xsdPath);



                string valorSelecionado = ddlTipoPessoa.SelectedValue;
                string textoSelecionado = ddlTipoPessoa.SelectedItem.Text;
                var indexCooperado = !string.IsNullOrEmpty(lblLinhaCooperado.Text) ? Convert.ToInt16(lblLinhaCooperado.Text) : 0;
                if (btnInserir.Text == "Inserir")
                {
                    if(!string.IsNullOrEmpty(txtCpfCnpj.Text) && !string.IsNullOrEmpty(valorSelecionado))
                    {
                        DataAcess dt = new DataAcess();
                        
                        var cliente = new Cliente();
                        cliente.CpfCnpj = txtCpfCnpj.Text;
                        cliente.TipoPessoa = valorSelecionado;

                        Clientes.Add(cliente);
                        gvCooperado.DataSource = Clientes; // substitua pelo seu método
                        gvCooperado.DataBind();
                        LimparCampos();
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "alerta", "alert('Por favor, preencha todos os dados');", true);
                    }
                    
                }else if(btnInserir.Text == "Alterar")
                {
                    
                    
                    Clientes[indexCooperado].CpfCnpj = txtCpfCnpj.Text;
                    Clientes[indexCooperado].TipoPessoa = valorSelecionado;
                    gvCooperado.DataSource = Clientes; // substitua pelo seu método
                    gvCooperado.DataBind();
                    LimparCampos();
                    btnInserir.Text = "Inserir";
                }
                else if (btnInserir.Text == "Excluir")
                {
                    Clientes.RemoveAt(indexCooperado);
                    gvCooperado.DataSource = Clientes;
                    gvCooperado.DataBind();
                    
                    btnInserir.Text = "Inserir";
                    btnCancelar_Click(null, null);
                }

                var operadores = new Dictionary<string, string>()
                {
                    { "001", "DIGIO" },
                    { "002", "Marcos" },
                    { "003", "Digio 12" },
                    { "004", "Digio 3" }
                };

                var listaDestino = new Dictionary<string, string>()
                {
                    { "002", "Marcos" },   // já existe
                    { "005", "Novo Operador" } // item que não existe em operadores
                };

                

                








            }
        }
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string valorSelecionado = ddlTipoPessoa.SelectedValue;
                string textoSelecionado = ddlTipoPessoa.SelectedItem.Text;
                LimparCampos();
                HabilitarCampos(true);
                HabilitaLinhasGrdView(gvCooperado, true);

            }
        }
        
        private void ValidarCampo()
        {
            txtCpfCnpj.BackColor = string.IsNullOrWhiteSpace(txtCpfCnpj.Text)
                ? System.Drawing.Color.LightYellow
                : System.Drawing.Color.White;
        }
        private void CarregarCombos()
        {
            ddlTipoPessoa.Items.Clear();
            ddlTipoPessoa.Items.Add(new ListItem("-- Selecione --", ""));
            ddlTipoPessoa.Items.Add(new ListItem("Pessoa Física", "F"));
            ddlTipoPessoa.Items.Add(new ListItem("Pessoa Jurídica", "J"));
        }
        protected void gvCooperado_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if(e.CommandName.Equals("Alterar"))
            {
                SelecionaLinhaGridCooperado(false, Convert.ToInt16(e.CommandArgument));
            }
        }
        protected void gvCooperado_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            SelecionaLinhaGridCooperado(true, e.RowIndex);
        }
        private void SelecionaLinhaGridCooperado(bool pExcluir, int pLinha)
        {
            btnInserir.Text = pExcluir ? "Excluir" : "Alterar";
            btnCancelar.Enabled = true;
            lblLinhaCooperado.Text = pLinha.ToString();
            AtribuirDadosTextBox(pLinha);
            HabilitarCampos(!pExcluir);
            HabilitaLinhasGrdView(gvCooperado, false);
        }
        private void AtribuirDadosTextBox(int iIndex)
        {
            txtCpfCnpj.Text = Clientes[iIndex].CpfCnpj;
            ddlTipoPessoa.SelectedValue = Clientes[iIndex].TipoPessoa;
        }
        private void HabilitaLinhasGrdView(GridView pGrdView, bool pHabilitar)
        {
            for (int i = 0; i < pGrdView.Rows.Count; i++)
                pGrdView.Rows[i].Enabled = pHabilitar;
        }
        private void LimparCampos()
        {
            txtCpfCnpj.Text = string.Empty;
            ddlTipoPessoa.SelectedValue = string.Empty;
        }
        private void HabilitarCampos(bool habilitar)
        {
            txtCpfCnpj.Enabled = habilitar;
            ddlTipoPessoa.Enabled = habilitar;
        }

        static void ValidarXml(string xmlString, string xsdPath)
        {
            var schemas = new XmlSchemaSet();
            schemas.Add(null, xsdPath);

            var doc = new XmlDocument();
            doc.LoadXml(xmlString);

            doc.Schemas = schemas;

            doc.Validate((s, e) =>
            {
                Console.WriteLine($"❌ Erro: {e.Message}");
                throw new Exception($"Erro: {e.Message}");
            });
        }
        private static void ValidationEventHandler(object sender, ValidationEventArgs e)
        {
            Console.WriteLine($"Erro de validação: {e.Message}");
        }

        private void CarregarOperadores()
        {
            //lstOrigem.Items.Clear();
            lstDestino.Items.Clear();


            //lista de todos os operadores na base
            Dictionary<string,string> operadoresTotais = new Dictionary<string,string>();
            operadoresTotais.Add("0001", "Operador 1");
            operadoresTotais.Add("0002", "Operador 2");
            operadoresTotais.Add("0003", "Operador 3");

            if (!operadoresTotais.ContainsKey("0004"))
            {
                Console.WriteLine($"Key is {0004} not found.");
            }

            //Aicionando todos os que ainda não tem na lista
            foreach (KeyValuePair<string, string> operador in operadoresTotais)
            {
                //Metodo para verificar se existe no tipo ListItem o valor contendo na chave do dicionario 
                var teste = lstOrigem.Items.FindByValue(operador.Key);
                if (lstOrigem.Items.FindByValue(operador.Key) == null)
                {
                    lstOrigem.Items.Add(new ListItem(string.Concat(operador.Key, " - ", operador.Value), operador.Key));
                }
            }
        }


    }
}