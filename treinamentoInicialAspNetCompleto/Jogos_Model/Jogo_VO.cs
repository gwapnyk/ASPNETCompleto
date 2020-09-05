using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;

namespace Jogos_Model
{
    public class Jogo_VO
    {
        private int iD;

        private string descricao;

        public Jogo_VO() 
        { }

        public Jogo_VO(int intID, string strDescricao)
        {
            this.settID(intID);
            this.settDescricao(strDescricao);
        }

        public int gettID() 
        {
            return this.iD;
        }

        public void settID(int intID) 
        {
            this.iD = intID;
        }

        public string gettDescricao() 
        {
            return this.descricao;
        }

        public void settDescricao(string strDescricao) 
        {
            this.descricao = strDescricao;
        }

        public List<Jogo_VO> Jogos_VO_Collection = new List<Jogo_VO>();
    }

    public class Familiares_VO
    {
        private int cOD;

        private string nome;

        private string sexo;

        private int idade;

        private double ganhoMensal;

        private double gastoMensal;

        private string observacao;

        public Familiares_VO()
        { }

        public Familiares_VO(int intCOD, string strNome, string strSexo, int intIdade, double dblGanhoMensal, double dblGastoMensal, string strObservacao)
        {
            this.settCOD(intCOD);
            this.settNome(strNome);
            this.settSexo(strSexo);
            this.settIdade(intIdade);
            this.settGanhoMensal(dblGanhoMensal);
            this.settGastoMensal(dblGastoMensal);
            this.settObservacao(strObservacao);
        }

        public int gettCOD()
        {
            return this.cOD;
        }

        public void settCOD(int intCOD)
        {
            this.cOD = intCOD;
        }

        public string gettNome()
        {
            return this.nome;
        }

        public void settNome(string strNome)
        {
            this.nome = strNome;
        }

        public string gettSexo()
        {
            return this.sexo;
        }

        public void settSexo(string strSexo)
        {
            this.sexo = strSexo;
        }

        public int gettIdade()
        {
            return this.idade;
        }

        public void settIdade(int intIdade)
        {
            this.idade = intIdade;
        }

        public double gettGanhoMensal()
        {
            return this.ganhoMensal;
        }

        public void settGanhoMensal(double dblGanhoMensal)
        {
            this.ganhoMensal = dblGanhoMensal;
        }

        public double gettGastoMensal()
        {
            return this.gastoMensal;
        }

        public void settGastoMensal(double dblGastoMensal)
        {
            this.gastoMensal = dblGastoMensal;
        }

        public string gettObservacao()
        {
            return this.observacao;
        }

        public void settObservacao(string strObservacao)
        {
            this.observacao = strObservacao;
        }

        public int COD
        {
            get { return cOD; }
            set { cOD = value; }
        }

        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        public string Sexo
        {
            get { return sexo; }
            set { sexo = value; }
        }

        public int Idade
        {
            get { return idade; }
            set { idade = value; }
        }

        public double GanhoMensal
        {
            get { return ganhoMensal; }
            set { ganhoMensal = value; }
        }

        public double GastoMensal
        {
            get { return gastoMensal; }
            set { gastoMensal = value; }
        }

        public string Observacao
        {
            get { return observacao; }
            set { observacao = value; }
        }

        public List<Familiares_VO> Familiares_VO_Collection = new List<Familiares_VO>();

    }

    public class Jogos_dos_Familiares_VO 
    {
        private Familiares_VO familiar;
        private Jogo_VO jogos;
        private string intensidade;
        private string observacao;

        public Jogos_dos_Familiares_VO() 
        { }

        public Jogos_dos_Familiares_VO(Familiares_VO objFamiliar, Jogo_VO objJogos, string strIntensidade, string strObservacao)
        {
            this.Familiar = objFamiliar;
            this.Jogos = objJogos;
            this.Intensidade = strIntensidade;
            this.Observacao = strObservacao;
        }

        public Familiares_VO Familiar
        {
            get { return familiar; }
            set { familiar = value; }
        }

        public Jogo_VO Jogos
        {
            get { return jogos; }
            set { jogos = value; }
        }

        public string Intensidade
        {
            get { return intensidade; }
            set { intensidade = value; }
        }

        public string Observacao
        {
            get { return observacao; }
            set { observacao = value; }
        }

        public Familiares_VO getFamiliar()
        {
            return this.familiar;
        }

        public void setFamiliar(Familiares_VO objFamiliares)
        {
            this.familiar = objFamiliares;
        }

        public Jogo_VO getJogos()
        {
            return this.jogos;
        }

        public void setJogos(Jogo_VO objJogos)
        {
            this.jogos = objJogos;
        }

        public string getIntensidade()
        {
            return this.intensidade;
        }

        public void setIntensidade(string strIntensidade)
        {
            this.intensidade = strIntensidade;
        }

        public string getObservacao()
        {
            return this.observacao;
        }

        public void setObservacao(string strObservacao)
        {
            this.observacao = strObservacao;
        }

        public List<Jogos_dos_Familiares_VO> Jogos_dos_Familiares_VO_Collection = new List<Jogos_dos_Familiares_VO>();
    }
}
    