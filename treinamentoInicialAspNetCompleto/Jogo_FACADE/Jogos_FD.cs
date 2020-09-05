using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Jogos_DAO_DAL;
using Jogos_Model;

namespace Jogo_FACADE
{
    public class Jogos_FD
    {
        Jogos_DAO objJogoDAO;

        public List<Jogo_VO> BDC() 
        {
            try
            {
                objJogoDAO = new Jogos_DAO();
                return objJogoDAO.BDC();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Jogo_VO> BDD()
        {
            try
            {
                objJogoDAO = new Jogos_DAO();
                return objJogoDAO.BDD();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable Consultar(Jogo_VO objJogo_VO)
        {
            try
            {
                objJogoDAO = new Jogos_DAO();
                return objJogoDAO.Consultar(objJogo_VO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Jogo_VO> Consultar(ref Jogo_VO objJogo_VO)
        {
            try
            {
                objJogoDAO = new Jogos_DAO();

                Object objJogoVO = (Object)objJogo_VO;
                objJogoDAO.Consultar(ref objJogoVO);
                return objJogo_VO.Jogos_VO_Collection;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Inserir (Jogo_VO objJogo_VO)
        {
            try
            {
                objJogoDAO = new Jogos_DAO();
                return objJogoDAO.Inserir(objJogo_VO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Excluir(Jogo_VO objJogo_VO)
        {
            try
            {
                objJogoDAO = new Jogos_DAO();
                return objJogoDAO.Excluir(objJogo_VO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Alterar(Jogo_VO objJogo_VO)
        {
            try
            {
                objJogoDAO = new Jogos_DAO();
                return objJogoDAO.Alterar(objJogo_VO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

    public class Familiares_FD  
    {
        Familiares_DAO objFamiliares_DAO;
        
        public DataTable Consultar(Familiares_VO objFamiliares_VO)
        {
            try
            {
                objFamiliares_DAO = new Familiares_DAO();
                return objFamiliares_DAO.Consultar(objFamiliares_VO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Familiares_VO> Consultar(ref Familiares_VO objFamiliares_VO)
        {
            try
            {
                objFamiliares_DAO = new Familiares_DAO();
                Object objFamiliaresVO = (Object)objFamiliares_VO;
                objFamiliares_DAO.Consultar(ref objFamiliaresVO);
                return objFamiliares_VO.Familiares_VO_Collection;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Inserir(Familiares_VO objFamiliares_VO)
        {
            try
            {
                objFamiliares_DAO = new Familiares_DAO();
                return objFamiliares_DAO.Inserir(objFamiliares_VO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Excluir(Familiares_VO objFamiliares_VO)
        {
            try
            {
                objFamiliares_DAO = new Familiares_DAO();
                return objFamiliares_DAO.Excluir(objFamiliares_VO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Alterar(Familiares_VO objFamiliares_VO)
        {
            try
            {
                objFamiliares_DAO = new Familiares_DAO();
                return objFamiliares_DAO.Alterar(objFamiliares_VO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

    public class Jogos_dos_Familiares_FD 
    {
        Jogos_dos_Familiares_DAO objJogos_dos_Familiares_DAO;

        public DataTable Consultar(Jogos_dos_Familiares_VO objJogos_dos_Familiares_VO)
        {
            try
            {
                objJogos_dos_Familiares_DAO = new Jogos_dos_Familiares_DAO();
                return objJogos_dos_Familiares_DAO.Consultar(objJogos_dos_Familiares_VO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Jogos_dos_Familiares_VO> Consultar(ref Jogos_dos_Familiares_VO objJogos_dos_Familiares_VO)
        {
            try
            {
                objJogos_dos_Familiares_DAO = new Jogos_dos_Familiares_DAO();
                Object objJogos_dos_FamiliaresVO = objJogos_dos_Familiares_VO;
                objJogos_dos_Familiares_DAO.Consultar(ref objJogos_dos_FamiliaresVO);
                return objJogos_dos_Familiares_VO.Jogos_dos_Familiares_VO_Collection;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Inserir(Jogos_dos_Familiares_VO objJogos_dos_Familiares_VO)
        {
            try
            {
                objJogos_dos_Familiares_DAO = new Jogos_dos_Familiares_DAO();
                return objJogos_dos_Familiares_DAO.Inserir(objJogos_dos_Familiares_VO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Excluir(Jogos_dos_Familiares_VO objJogos_dos_Familiares_VO)
        {
            try
            {
                objJogos_dos_Familiares_DAO = new Jogos_dos_Familiares_DAO();
                return objJogos_dos_Familiares_DAO.Excluir(objJogos_dos_Familiares_VO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Alterar(Jogos_dos_Familiares_VO objJogos_dos_Familiares_VO)
        {
            try
            {
                objJogos_dos_Familiares_DAO = new Jogos_dos_Familiares_DAO();
                return objJogos_dos_Familiares_DAO.Alterar(objJogos_dos_Familiares_VO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void GeraExcelInterop(string strNomeDaPlanilha)
        {
            objJogos_dos_Familiares_DAO = new Jogos_dos_Familiares_DAO();
            objJogos_dos_Familiares_DAO.GeraExcelInterop(strNomeDaPlanilha);
        }

    }
}
