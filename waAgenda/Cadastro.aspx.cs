using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidarCampo();
            if (!IsPostBack)
            {
                CarregarCombos();
                gvCooperado.DataSource = new List<object>();
                gvCooperado.DataBind();

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


    }
}