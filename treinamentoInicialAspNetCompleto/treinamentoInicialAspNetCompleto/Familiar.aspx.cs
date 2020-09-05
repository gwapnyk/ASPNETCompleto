using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Jogos_BLL;
using System.Data;

namespace treinamentoInicialAspNetCompleto
{
    public partial class Familiar : System.Web.UI.Page
    {
        Familiares objFamiliares;
        DataView dvFamiliares;

        protected void Page_Load(object sender, EventArgs e)
        {
            //chama apenas na primeira carga da pagina 
            if (!Page.IsPostBack)
            {
                //Permite a paginação do grid e expecifica o tamanho da pagina
                dtgdvwFamiliar.AllowPaging = true;
                dtgdvwFamiliar.PageSize = 3;

                //Permite a ordenação do grid e a opção de ordenação do grid
                dtgdvwFamiliar.AllowSorting = true;

                //Inicializa a expressão de ordenação
                ViewState["SortExpression"] = "Nome ASC";

                //Popula o GRID
                ConsultarBD();

                this.FindControl("dvCadastro").Visible = false;
            }
        }

        protected void dtgdvwFamiliar_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFamiliar.Text = dtgdvwFamiliar.SelectedRow.Cells[1].Text + '-' + dtgdvwFamiliar.SelectedRow.Cells[2].Text.ToString();
        }

        protected void btnPesquisa_Click(object sender, EventArgs e)
        {
            dtgdvwFamiliar.EditIndex = -1;
            ConsultarBD(txtFamiliar.Text.Contains("-") ? txtFamiliar.Text.Substring(txtFamiliar.Text.IndexOf("-") + 1) : txtFamiliar.Text.ToString(), 
                Convert.ToInt32(txtFamiliar.Text.Contains("-") ? Convert.ToInt32(txtFamiliar.Text.Substring(0, txtFamiliar.Text.IndexOf("-"))) : 0));
        }
        
        public void ConsultarBD(string strFamiliares = null, int ? intCod = null)
        {
            objFamiliares  = new Familiares();

            dvFamiliares = objFamiliares.Consultar(strFamiliares, intCod).DefaultView;
            dvFamiliares.Sort = ViewState["SortExpression"].ToString();

            dtgdvwFamiliar.DataSource = dvFamiliares;
            dtgdvwFamiliar.DataBind();
        }

        protected void btnInserirFamiliar_Click(object sender, EventArgs e)
        {
            //Tem que estar em readOnly = true
            this.FindControl("dvCadastro").Visible = true;

            //Copia para o Nome do Familiar o nome digitado no campo de Pesquisa se houver algun nome
            if (!string.IsNullOrEmpty(txtFamiliar.Text))
            {
                txtNome.Text = txtFamiliar.Text.Contains("-") ? txtFamiliar.Text.Substring(txtFamiliar.Text.IndexOf("-")) : txtFamiliar.Text;
            }
        }

        public void InserirFamiliar(string strNome, string strSexo, int intIdade, double dblGanhoMensal, double dblGastoMensal, string strObservacao) 
        {
            try
            {
                objFamiliares = new Familiares();

                if (objFamiliares.Inserir(strNome, strSexo, intIdade, dblGanhoMensal, dblGastoMensal, strObservacao))
                {
                    ClientScript.RegisterStartupScript(Page.GetType(), "Inseriu", "alert('Parabens!! Inseriu')", true);
                }
                else 
                {
                    ClientScript.RegisterStartupScript(Page.GetType(), "NaoInseriu", "alert('Não Inseriu')", true);
                }
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(Page.GetType(), "crash", "alert('ERRO!!! Não Inseriu')", true);
            }
        }

        public void ExcluirFamiliar(int intCod) 
        {
            try
            {
                objFamiliares = new Familiares();

                objFamiliares.Excluir(intCod);
                ClientScript.RegisterStartupScript(this.Page.GetType(), "Deletar_Familiar_", "alert('Sucesso ao Excluir Familiar == > ');");
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.Page.GetType(), "Deletar_Familiar_ERRO", "alert('Erro ao Excluir Familiar == > " + ex.Message.Substring(0, 70).ToString() + "');", true);
            }
        }

        protected void dtgdvwFamiliar_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            ExcluirFamiliar(Convert.ToInt32(dtgdvwFamiliar.Rows[e.RowIndex].Cells[1].Text.ToString()));
            dtgdvwFamiliar.EditIndex = -1;
            ConsultarBD();   
        }

        protected void dtgdvwFamiliar_RowEditing(object sender, GridViewEditEventArgs e)
        {
            
            //Salvo o valor antigo do texto no textbox
            txtFamiliar.Text = dtgdvwFamiliar.Rows[e.NewEditIndex].Cells[1].Text.ToString() + "-" + HttpUtility.HtmlDecode(dtgdvwFamiliar.Rows[e.NewEditIndex].Cells[2].Text.ToString());
            txtFamiliar.ReadOnly = true;
            //Recolocar em modo edição para linha selecionada
            dtgdvwFamiliar.EditIndex = e.NewEditIndex;
            //Rebind(reacossia e redistribui o controle do grid view para mostrar os dados no modo de edição)
            ConsultarBD();
            dtgdvwFamiliar.Rows[e.NewEditIndex].Cells[1].Visible = false;
        }

        protected void dtgdvwFamiliar_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Alterar(txtFamiliar.Text.Contains("-") ? Convert.ToInt32(txtFamiliar.Text.Substring(0, txtFamiliar.Text.IndexOf("-"))) : Convert.ToInt32(txtFamiliar.Text.ToString()), e.NewValues[1].ToString(),
                    e.NewValues[2].ToString(), Convert.ToInt32(e.NewValues[3].ToString()), Convert.ToDouble(e.NewValues[4].ToString()), Convert.ToDouble(e.NewValues[5].ToString()), e.NewValues[6].ToString());
            dtgdvwFamiliar.EditIndex = -1;
            txtFamiliar.ReadOnly = false;
            ConsultarBD();
            dtgdvwFamiliar.Rows[e.RowIndex].Cells[1].Visible = true;
        }

        public void Alterar(int intCOD, string strNome, string strSexo, int intIdade, double dblGanhoMensal, double dblGastoMensal, string strObservacao) 
        {
            try
            {
                objFamiliares = new Familiares();

                if (objFamiliares.Alterar(intCOD, HttpUtility.HtmlDecode(strNome), strSexo, intIdade, dblGanhoMensal, dblGastoMensal, HttpUtility.HtmlDecode(strObservacao)))
                {
                    ClientScript.RegisterStartupScript(Page.GetType(), "AlterouOk", "alert('Alterou')", true);
                }
                else
                {
                    ClientScript.RegisterStartupScript(Page.GetType(), "AlterouFalhou", "alert('NAO Alterou')", true);
                }
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(Page.GetType(), "crash", "alert('ERRO!! NAO Alterou')", true);
            }
        }
        protected void dtgdvwFamiliar_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            //Sai do modo edição //Despreza o que foi alterado
            dtgdvwFamiliar.EditIndex = -1;
            ConsultarBD();
        }

        protected void dtgdvwFamiliar_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dtgdvwFamiliar.PageIndex = e.NewPageIndex;
            ConsultarBD();
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            //Insere o Familiar de fato no BD
            InserirFamiliar(txtNome.Text, txtSexo.Text, Convert.ToInt32(txtIdade.Text), Convert.ToDouble(txtGanhoMensal.Text), Convert.ToDouble(txtGanhoMensal.Text), txtObservacao.Text);

            this.FindControl("dvCadastro").Visible = false;
            //Limpar os textos internos da divCadastro
            foreach (Control ctlControleHTML in this.Controls)
            {
                if (ctlControleHTML is TextBox)
                {
                    ((TextBox)ctlControleHTML).Text = string.Empty;
                }
            }

            ConsultarBD();
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            this.FindControl("dvCadastro").Visible = false;
            //Limpar os textos internos da divCadastro
            foreach (Control ctlControleHTML in this.Controls)
            {
                if (ctlControleHTML is TextBox)
                {
                    ((TextBox)ctlControleHTML).Text = string.Empty;
                }
            }

            ConsultarBD();
        }
    }
}