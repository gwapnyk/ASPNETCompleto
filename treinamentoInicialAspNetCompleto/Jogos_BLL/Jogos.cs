using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Jogos_Model;
using Jogo_FACADE;
using System.IO;

namespace Jogos_BLL
{
    public class Jogos
    {
        StreamReader objLeitorDeTexto;
        string strLinhaLida, strValorAntigo;

        public List<string> Import() 
        {
            try
            {
                List<string> Retorno = new List<string>();

                objLeitorDeTexto = new StreamReader(@"C:\PROGRAMAÇÃO\C#\Windows\windows forms\Exercicios\Jogos.txt");
                strLinhaLida = objLeitorDeTexto.ReadLine();

                while (strLinhaLida != null)
                {
                    Retorno.Add(strLinhaLida);
                    strLinhaLida = objLeitorDeTexto.ReadLine();
                }
                return Retorno;
            }
            catch (Exception ex)
            {
                throw new Exception("Falha ao Importar" + ex.Message);
            }
            finally 
            {
                objLeitorDeTexto.Close();
            }
        }

        public List<string> BDC()
        {
            try
            {
                List<string> Retorno = new List<string>();

                Jogo_VO objJogo_VO = new Jogo_VO();
                Jogos_FD objJogo_FD = new Jogos_FD();

                objJogo_VO.Jogos_VO_Collection = objJogo_FD.BDC();

                foreach (Jogo_VO item in objJogo_VO.Jogos_VO_Collection)
                {
                    Retorno.Add(item.gettDescricao());
                }

                return Retorno;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<string> BDD()
        {
            try
            {
                List<string> Retorno = new List<string>();

                Jogo_VO objJogo_VO = new Jogo_VO();
                Jogos_FD objJogo_FD = new Jogos_FD();

                objJogo_VO.Jogos_VO_Collection = objJogo_FD.BDD();

                foreach (Jogo_VO item in objJogo_VO.Jogos_VO_Collection)
                {
                    Retorno.Add(item.gettDescricao());
                }

                return Retorno;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable Consultar(int? intId = null, string strJogos = null)
        {
            try
            {
                Jogo_VO objJogo_VO = new Jogo_VO();
                objJogo_VO.settID((Convert.ToInt32((intId == null ? 0 : intId))));
                objJogo_VO.settDescricao(strJogos);
                Jogos_FD objJogo_FD = new Jogos_FD();

                return objJogo_FD.Consultar(objJogo_VO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Inserir(string strJogos)
        {
            try
            {
                Jogo_VO objJogo_VO = new Jogo_VO();
                objJogo_VO.settDescricao(strJogos);
                Jogos_FD objJogo_FD = new Jogos_FD();

                return objJogo_FD.Inserir(objJogo_VO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Excluir(int intID)
        {
            try
            {
                Jogo_VO objJogo_VO = new Jogo_VO();
                objJogo_VO.settID(intID);
                Jogos_FD objJogo_FD = new Jogos_FD();

                return objJogo_FD.Excluir(objJogo_VO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Alterar(int intID, string strJogos)
        {
            try
            {
                Jogo_VO objJogo_VO = new Jogo_VO(intID, strJogos);

                Jogos_FD objJogo_FD = new Jogos_FD();

                return objJogo_FD.Alterar(objJogo_VO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

    public class Familiares 
    {
        public DataTable Consultar(string strNome = null, int ? intCod = null)
        {
            try
            {
                Familiares_VO objFamiliares_VO = new Familiares_VO();
                objFamiliares_VO.settCOD(Convert.ToInt32(intCod == null ? 0 : intCod));
                objFamiliares_VO.settNome(strNome);

                Familiares_FD objFamiliares_FD = new Familiares_FD();

                return objFamiliares_FD.Consultar(objFamiliares_VO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Inserir(string strNome, string strSexo, int intIdade, double dblGanhoMensal, double dblGastoMensal, string strObservacao)
        {
            try
            {
                Familiares_VO objFamiliares_VO = new Familiares_VO();
                objFamiliares_VO.settNome(strNome);
                objFamiliares_VO.settSexo(strSexo);
                objFamiliares_VO.settIdade(intIdade);
                objFamiliares_VO.settGanhoMensal(dblGanhoMensal);
                objFamiliares_VO.settGastoMensal(dblGastoMensal);
                objFamiliares_VO.settObservacao(strObservacao);

                Familiares_FD objFamiliares_FD = new Familiares_FD();

                return objFamiliares_FD.Inserir(objFamiliares_VO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Excluir(int intCOD)
        {
            try
            {
                Familiares_VO objFamiliares_VO = new Familiares_VO();
                objFamiliares_VO.settCOD(intCOD);
                Familiares_FD objFamiliares_FD = new Familiares_FD();

                return objFamiliares_FD.Excluir(objFamiliares_VO);
            }
            catch (Exception ex)
            {
                 throw ex;
            }
        }

        public bool Alterar(int intCOD, string strNome, string strSexo, int intIdade, double dblGanhoMensal, double dblGastoMensal, string strObservacao)
        {
            try
            {
                Familiares_VO objFamiliares_VO = new Familiares_VO(intCOD, strNome, strSexo, intIdade, dblGanhoMensal, dblGastoMensal, strObservacao);

                Familiares_FD objFamiliares_FD = new Familiares_FD();

                return objFamiliares_FD.Alterar(objFamiliares_VO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

    public class Jogos_dos_Familiares
    {
        public DataTable Consultar(Familiares_VO objFamiliarVO, Jogo_VO objJogosVO)
        {
            try
            {
                Jogos_dos_Familiares_VO objJogos_dos_Familiares_VO = new Jogos_dos_Familiares_VO();
                objJogos_dos_Familiares_VO.Familiar = objFamiliarVO;
                objJogos_dos_Familiares_VO.Jogos = objJogosVO;

                Jogos_dos_Familiares_FD objJogos_dos_Familiares_FD = new Jogos_dos_Familiares_FD();

                return objJogos_dos_Familiares_FD.Consultar(objJogos_dos_Familiares_VO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Inserir(Familiares_VO objFamiliarVO, Jogo_VO objJogosVO, string strIntensidade, string strObservacao)
        {
            try
            {
                Jogos_dos_Familiares_VO objJogos_dos_Familiares_VO = new Jogos_dos_Familiares_VO();
                objJogos_dos_Familiares_VO.Familiar = objFamiliarVO;
                objJogos_dos_Familiares_VO.Jogos = objJogosVO;
                objJogos_dos_Familiares_VO.Intensidade = strIntensidade;
                objJogos_dos_Familiares_VO.Observacao = strObservacao;

                Jogos_dos_Familiares_FD objJogos_dos_Familiares_FD = new Jogos_dos_Familiares_FD();

                return objJogos_dos_Familiares_FD.Inserir(objJogos_dos_Familiares_VO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Excluir(Familiares_VO objFamiliarVO, Jogo_VO objJogosVO)
        {
            try
            {
                Jogos_dos_Familiares_VO objJogos_dos_Familiares_VO = new Jogos_dos_Familiares_VO();
                objJogos_dos_Familiares_VO.Familiar = objFamiliarVO;
                objJogos_dos_Familiares_VO.Jogos = objJogosVO;
                Jogos_dos_Familiares_FD objJogos_dos_Familiares_FD = new Jogos_dos_Familiares_FD();

                return objJogos_dos_Familiares_FD.Excluir(objJogos_dos_Familiares_VO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Alterar(Familiares_VO objFamiliarVO, Jogo_VO objJogosVO, string strIntensidade, string strObservacao)
        {
            try
            {
                Jogos_dos_Familiares_VO objJogos_dos_Familiares_VO = new Jogos_dos_Familiares_VO();
                objJogos_dos_Familiares_VO.Familiar = objFamiliarVO;
                objJogos_dos_Familiares_VO.Jogos = objJogosVO;
                objJogos_dos_Familiares_VO.Intensidade = strIntensidade;
                objJogos_dos_Familiares_VO.Observacao = strObservacao;

                Jogos_dos_Familiares_FD objJogos_dos_Familiares_FD = new Jogos_dos_Familiares_FD();

                return objJogos_dos_Familiares_FD.Alterar(objJogos_dos_Familiares_VO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void GeraExcelInterop(string strNomeDaPlanilha) 
        {
            Jogos_dos_Familiares_FD objJogos_dos_Familiares_FD = new Jogos_dos_Familiares_FD();
            objJogos_dos_Familiares_FD.GeraExcelInterop(strNomeDaPlanilha);
        }
    }
}
