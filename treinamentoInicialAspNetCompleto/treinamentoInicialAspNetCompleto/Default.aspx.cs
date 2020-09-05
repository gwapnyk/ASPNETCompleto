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
    public partial class _Default : Page
    {
        Jogos objJogosBll;
        DataView dvJogos;

        protected void Page_Load(object sender, EventArgs e)
        {
            //chama apenas na primeira carga da pagina 
            if (!Page.IsPostBack)
            {
                //Permite a paginação do grid e expecifica o tamanho da pagina
                dtgdvwJogos.AllowPaging = true;
                dtgdvwJogos.PageSize = 3;
                
                //Permite a ordenação do grid e a opção de ordenação do grid
                dtgdvwJogos.AllowSorting = true;

                //Inicializa a expressão de ordenação
                ViewState["SortExpression"] = "Descricao ASC";
                
                //Popula o GRID
                ConsultarBD();
                
            }
        }

        protected void btnDesvCon_Click(object sender, EventArgs e)
        {
            string strScrpit = @"if(window.confirm('Escolha OK ou Cancelar')){
                                    alert('Voce escolheu OK')
                               }else{
                                    alert('Voce escolheu Cancelar')}";
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "desvioCondicional", strScrpit, true);
        }

        protected void btnImport_Click(object sender, EventArgs e)
        {
            objJogosBll = new Jogos();

            foreach (string item in objJogosBll.Import())
            {
                lstbxJogos.Items.Add(item);
            }
        }

        protected void btnBDC_Click(object sender, EventArgs e)
        {
            objJogosBll = new Jogos();

            foreach (string item in objJogosBll.BDC()) 
            {
                lstbxJogos.Items.Add(item);
            }
        }

        protected void btnBDD_Click1(object sender, EventArgs e)
        {
            objJogosBll = new Jogos();

            foreach (string item in objJogosBll.BDD())
            {
                lstbxJogos.Items.Add(item);
            }
        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            ConsultarBD(Convert.ToInt32(string.IsNullOrEmpty(txtJogos.Text) ? null : txtJogos.Text.Contains("-") ? txtJogos.Text.Substring(0, txtJogos.Text.IndexOf("-")) : null),
                txtJogos.Text.Contains("-") ? txtJogos.Text.Substring(txtJogos.Text.IndexOf("-") + 1) : txtJogos.Text);
        }

        public void ConsultarBD(int ? intId = null, string strJogos = null)
        {
            objJogosBll = new Jogos();

            //Obtem a dataview da datatableJogos que vem pelo consultaBD da BLL e ascossia essa visao a ordenação
            dvJogos = objJogosBll.Consultar(intId, strJogos).DefaultView;

            //Configura a coluna de ordenação e a ordem de ordenação
            dvJogos.Sort = ViewState["SortExpression"].ToString();

            dtgdvwJogos.DataSource = dvJogos;
            dtgdvwJogos.DataBind();
        }

        protected void dtgdvwJogos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            //Configura o indice da pagina nova a ser mostrada
            dtgdvwJogos.PageIndex = e.NewPageIndex;

            //Rebaind reacossia e re distribui o controle do gridview para mostrar meus dados na nova pagina
            ConsultarBD();
            
        }

        protected void dtgdvwJogos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Excluir(Convert.ToInt32(dtgdvwJogos.Rows[e.RowIndex].Cells[1].Text.ToString()));
            dtgdvwJogos.EditIndex = - 1;
            ConsultarBD();
        }

        protected void dtgdvwJogos_RowEditing(object sender, GridViewEditEventArgs e)
        {
            //Salvo o valor antigo do texto no textbox
            txtJogos.Text = dtgdvwJogos.Rows[e.NewEditIndex].Cells[1].Text.ToString() + "-" + HttpUtility.HtmlDecode(dtgdvwJogos.Rows[e.NewEditIndex].Cells[2].Text.ToString());
            txtJogos.ReadOnly = true;
            //Recolocar em modo edição para linha selecionada
            dtgdvwJogos.EditIndex = e.NewEditIndex;
            //Rebind(reacossia e redistribui o controle do grid viewpara mostrar os dados no modo de edição)
            ConsultarBD();
            dtgdvwJogos.Rows[e.NewEditIndex].Cells[1].Visible = false;
        }

        protected void dtgdvwJogos_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Alterar(txtJogos.Text.Contains("-") ? Convert.ToInt32(txtJogos.Text.Substring(0, txtJogos.Text.IndexOf("-"))) : Convert.ToInt32(txtJogos.Text.ToString()), e.NewValues[1].ToString());
            dtgdvwJogos.EditIndex = -1;
            txtJogos.ReadOnly = false;
            ConsultarBD();
            dtgdvwJogos.Rows[e.RowIndex].Cells[1].Visible = true;
        }

        protected void dtgdvwJogos_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtJogos.Text = HttpUtility.HtmlDecode(dtgdvwJogos.SelectedRow.Cells[1].Text + "-" + dtgdvwJogos.SelectedRow.Cells[2].Text);
        }

        protected void dtgdvwJogos_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            //Sai do modo edição //Despreza o que foi alterado
            dtgdvwJogos.EditIndex = -1;
            ConsultarBD();
        }

        protected void btnInserir_Click(object sender, EventArgs e)
        {
            Inserir(txtJogos.Text.Contains("-") ? txtJogos.Text.Substring(txtJogos.Text.IndexOf("-") + 1) : txtJogos.Text.ToString());
            dtgdvwJogos.EditIndex = -1; //Coloca um grid em modo exibição, e retirando do modo edição
            ConsultarBD();
        }

        public void Inserir(string strJogos) 
        {
            try
            {
                objJogosBll = new Jogos();

                if (objJogosBll.Inserir(strJogos))
                {
                    ClientScript.RegisterStartupScript(Page.GetType(), "InseridoOk", "alert('INSERIU')", true);
                }
                else 
                {
                    ClientScript.RegisterStartupScript(Page.GetType(), "InseridoFalhou", "alert('NAO INSERIU')", true);
                }
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(Page.GetType(), "crash","alert('ERRO!! NAO INSERIU')", true);
            }
        }

        protected void btnExcluir_Click(object sender, EventArgs e)
        {
            Excluir(txtJogos.Text.Contains("-") ? (Convert.ToInt32(txtJogos.Text.Substring(0, txtJogos.Text.IndexOf("-")))) : Convert.ToInt32(txtJogos.Text.ToString()));
        //    Excluir(Convert.ToInt32("20"));
            dtgdvwJogos.EditIndex = -1;
            ConsultarBD();
        }

        public void Excluir(int intJogos)
        {
            try
            {
                objJogosBll = new Jogos();

                //objJogosBll.Excluir(intJogos);
                //ClientScript.RegisterStartupScript(Page.GetType(), "ExcluirOk", "alert('Excluiu')", true);
                if (objJogosBll.Excluir(intJogos))
                {
                    ClientScript.RegisterStartupScript(Page.GetType(), "ExcluirOk", "alert('Excluiu')", true);
                }
                else
                {
                    ClientScript.RegisterStartupScript(Page.GetType(), "ExcluirFalhou", "alert('NAO Excluiu')", true);
                }
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(Page.GetType(), "crash", "alert('ERRO!! NAO Excluiu')", true);
            }
        }

        protected void btnAlterar_Click(object sender, EventArgs e)
        {
            Alterar(Convert.ToInt32(dtgdvwJogos.SelectedRow.Cells[1].Text), txtJogos.Text.Contains("-") ? txtJogos.Text.Substring(txtJogos.Text.IndexOf("-") + 1) : txtJogos.Text.ToString());
            dtgdvwJogos.EditIndex = -1;
            ConsultarBD();
        }

        public void Alterar(int intId, string strJogos)
        {
            try
            {
                objJogosBll = new Jogos();

                if (objJogosBll.Alterar(intId, HttpUtility.HtmlDecode(strJogos)))
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
    }
}