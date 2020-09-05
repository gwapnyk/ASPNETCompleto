using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using Jogos_Model;
using System.Data;

namespace Jogos_DAO_DAL
{
    public class Jogos_DAO : DAO_DAO
    {
        OleDbDataReader objDataReader;

        Jogo_VO objJogo_VO;

        public List<Jogo_VO> BDC() 
        {
            try
            {
                objJogo_VO = new Jogo_VO();

                AbreConn();

                objCommand = new OleDbCommand("SELECT ID,Descricao FROM Jogos", gettObjConnection());

                objDataReader = objCommand.ExecuteReader();

                while (objDataReader.Read())
                {
                    objJogo_VO.Jogos_VO_Collection.Add(new Jogo_VO(Convert.ToInt32(objDataReader["ID"].ToString()), objDataReader["Descricao"].ToString()));
                }
                return objJogo_VO.Jogos_VO_Collection;
            }
            catch (Exception ex)
            {
                throw new Exception("Falha ao Consultar ==> " + ex.Message);
            }
            finally 
            {
                FechaConn();
            }
        }

        public List<Jogo_VO> BDD()
        {
            try
            {
                objJogo_VO = new Jogo_VO();

                objCommand = new OleDbCommand("SELECT ID,Descricao FROM Jogos", gettObjConnection());

                objDataAdapter = new OleDbDataAdapter(objCommand);

                objTable = new DataTable();

                objDataAdapter.Fill(objTable);

                foreach (DataRow item in objTable.Rows)
                {
                    objJogo_VO.Jogos_VO_Collection.Add(new Jogo_VO(Convert.ToInt32(item["ID"].ToString()), item["Descricao"].ToString()));
                }
                return objJogo_VO.Jogos_VO_Collection;
            }
            catch (Exception ex)
            {
                throw new Exception("Falha ao Consultar ==> " + ex.Message);
            }
        }

        public override DataTable Consultar(Object objJogo_VO)
        {
            try
            {
                Jogo_VO objJogosVO = (Jogo_VO)objJogo_VO;

                if (objJogosVO.gettID() > 0)
                {
                    objCommand = new OleDbCommand("SELECT ID,Descricao FROM Jogos WHERE ID = :intID", gettObjConnection());
                    objCommand.Parameters.AddWithValue(":intID", objJogosVO.gettID());   
                }
                else if (string.IsNullOrEmpty(objJogosVO.gettDescricao()))
                {
                    objCommand = new OleDbCommand("SELECT ID,Descricao FROM Jogos", gettObjConnection());
                }
                else 
                {
                    objCommand = new OleDbCommand("SELECT ID,Descricao FROM Jogos WHERE Descricao = :parJogos", gettObjConnection());
                    objCommand.Parameters.AddWithValue(":parJogos", objJogosVO.gettDescricao());                
                }

                objDataAdapter = new OleDbDataAdapter(objCommand);

                objTable = new DataTable();

                objDataAdapter.Fill(objTable);

                return objTable;
            }
            catch (Exception ex)
            {
                throw new Exception("Falha ao Consultar ==> " + ex.Message);
            }
        }

        public override List<Object> Consultar(ref Object objJogo_VO)
        {
            try
            {
                Jogo_VO objJogosVO = (Jogo_VO)objJogo_VO;

                if (objJogosVO.gettID() > 0)
                {
                    objCommand = new OleDbCommand("SELECT ID,Descricao FROM Jogos WHERE ID = :intID", gettObjConnection());
                    objCommand.Parameters.AddWithValue(":intID", objJogosVO.gettID());
                }

                else if (string.IsNullOrEmpty(objJogosVO.gettDescricao()))
                {
                    objCommand = new OleDbCommand("SELECT ID,Descricao FROM Jogos", gettObjConnection());
                }
                else
                {
                    objCommand = new OleDbCommand("SELECT ID,Descricao FROM Jogos WHERE Descricao = :parJogos", gettObjConnection());
                    objCommand.Parameters.AddWithValue(":parJogos", objJogosVO.gettDescricao());
                }

                objDataAdapter = new OleDbDataAdapter(objCommand);

                objTable = new DataTable();

                objDataAdapter.Fill(objTable);

                List<Object> objListaRetorno = new List<object>();

                foreach (DataRow item in objTable.Rows)
                {
                    objJogosVO.Jogos_VO_Collection.Add(new Jogo_VO(Convert.ToInt32(item["ID"].ToString()), item["Descricao"].ToString()));
                }
                objListaRetorno.AddRange(objJogosVO.Jogos_VO_Collection.ToArray());
                return objListaRetorno;
            }
            catch (Exception ex)
            {
                throw new Exception("Falha ao Consultar ==> " + ex.Message);
            }
        }

        public override bool Inserir(Object objJogos_VO)
        {
            try
            {
                Jogo_VO objJogosVO = (Jogo_VO)objJogos_VO;

                AbreConn();

                objCommand = new OleDbCommand("INSERT INTO Jogos(Descricao) VALUES (:parJogos)", gettObjConnection());
                objCommand.Parameters.AddWithValue("parJogos", objJogosVO.gettDescricao());

                if (objCommand.ExecuteNonQuery() > 0)
                {
                    return true;
                }
                else 
                {
                    return false;
                }
                
            }
            catch (Exception ex)
            {
                throw new Exception("Falha ao Inserir ==> " + ex.Message);
            }
            finally
            {
                FechaConn();
            }
        }

        public override bool Excluir(Object objJogos_VO)
        {
            try
            {
                Jogo_VO objJogosVO = (Jogo_VO)objJogos_VO;

                AbreConn();

                objCommand = new OleDbCommand("DELETE FROM Jogos WHERE ID = :intID", gettObjConnection());
                objCommand.Parameters.AddWithValue("intID", objJogosVO.gettID());

                if (objCommand.ExecuteNonQuery() > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Falha ao Excluir ==> " + ex.Message);
            }
            finally
            {
                FechaConn();
            }
        }

        public override bool Alterar(Object objJogos_VO)
        {
            try
            {
                Jogo_VO objJogosVO = (Jogo_VO)objJogos_VO;

                AbreConn();

                objCommand = new OleDbCommand("UPDATE Jogos SET Descricao = :parJogos WHERE ID = :parID", gettObjConnection());
                objCommand.Parameters.AddWithValue("parJogos", objJogosVO.gettDescricao());
                objCommand.Parameters.AddWithValue("parID", objJogosVO.gettID());

                if (objCommand.ExecuteNonQuery() > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Falha ao Alterar ==> " + ex.Message);
            }
            finally
            {
                FechaConn();
            }
        }
    }

    public class Familiares_DAO : DAO_DAO 
    {
        public override DataTable Consultar(Object objFamiliares_VO) 
        {
            try
            {
                Familiares_VO objFamiliaresVO = (Familiares_VO)objFamiliares_VO;

                AbreConn();

                if (objFamiliaresVO.gettCOD() > 0)
                {
                    objCommand = new OleDbCommand("SELECT COD,Nome,Sexo,Idade,Ganho_Mensal,Gasto_Mensal,[Observação] FROM Familiares WHERE COD = :parCOD", gettObjConnection());
                    objCommand.Parameters.AddWithValue("parCOD", objFamiliaresVO.COD);
                }
                else if (string.IsNullOrEmpty(objFamiliaresVO.Nome))
                {
                    objCommand = new OleDbCommand("SELECT COD,Nome,Sexo,Idade,Ganho_Mensal,Gasto_Mensal,[Observação] FROM Familiares", gettObjConnection());
                }
                else
                {
                    objCommand = new OleDbCommand("SELECT COD,Nome,Sexo,Idade,Ganho_Mensal,Gasto_Mensal,[Observação] FROM Familiares WHERE Nome = :parNome", gettObjConnection());
                    objCommand.Parameters.AddWithValue("parNome", objFamiliaresVO.Nome);
                }

                objDataAdapter = new OleDbDataAdapter(objCommand);

                objTable = new DataTable();

                objDataAdapter.Fill(objTable);

                return objTable;
            }
            catch (Exception ex)
            {
                throw new Exception("Falha ao Consultar de Familiares ==> " + ex.Message);
            }
            finally
            {
                FechaConn();
            }
        }

        public override List<Object> Consultar(ref Object objFamiliares_VO) 
        {
            try
            {
                Familiares_VO objFamiliaresVO = (Familiares_VO)objFamiliares_VO;

                AbreConn();

                if (objFamiliaresVO.gettCOD() > 0)
                {
                    objCommand = new OleDbCommand("SELECT COD,Nome,Sexo,Idade,Ganho_Mensal,Gasto_Mensal,[Observação] FROM Familiares WHERE COD = :parCOD", gettObjConnection());
                    objCommand.Parameters.AddWithValue("parCOD", objFamiliaresVO.COD);
                }
                else if (string.IsNullOrEmpty(objFamiliaresVO.Nome))
                {
                    objCommand = new OleDbCommand("SELECT COD,Nome,Sexo,Idade,Ganho_Mensal,Gasto_Mensal,[Observação] FROM Familiares", gettObjConnection());
                }
                else 
                {
                    objCommand = new OleDbCommand("SELECT COD,Nome,Sexo,Idade,Ganho_Mensal,Gasto_Mensal,[Observação] FROM Familiares WHERE Nome = :parNome", gettObjConnection());
                    objCommand.Parameters.AddWithValue("parNome", objFamiliaresVO.Nome);
                }

                objDataAdapter = new OleDbDataAdapter(objCommand);

                objTable = new DataTable();

                objDataAdapter.Fill(objTable);

                List<Object> objListaRetorno = new List<object>();

                foreach (DataRow item in objTable.Rows)
	            {
                    objFamiliaresVO.Familiares_VO_Collection.Add(new Familiares_VO(Convert.ToInt32(item["COD"].ToString())
                                                                                   ,item["Nome"].ToString()
                                                                                   ,item["Sexo"].ToString()
                                                                                   ,Convert.ToInt32(item["Idade"].ToString())
                                                                                   ,Convert.ToDouble(item["Ganho_Mensal"].ToString())
                                                                                   ,Convert.ToDouble(item["Gasto_Mensal"].ToString())
                                                                                   ,item["Observação"].ToString()
                                                               ));
                }
                objListaRetorno.AddRange(objFamiliaresVO.Familiares_VO_Collection.ToArray());
                return objListaRetorno;
            }
            catch (Exception ex)
            {
                throw new Exception("Falha ao Consultar de Familiares ==> " + ex.Message);
            }
            finally
            {
                FechaConn();
            }
        }

        public override bool Inserir(Object objFamiliares_VO)
        {
            try
            {
                Familiares_VO objFamiliaresVO = (Familiares_VO)objFamiliares_VO;

                AbreConn();

                objCommand = new OleDbCommand(
                    @"INSERT INTO Familiares(Nome,Sexo,Idade,Ganho_Mensal,Gasto_Mensal,[Observação]) 
                    VALUES (:parNome, :parSexo, :parIdade, :parGanho_Mensal, :parGasto_Mensal, :parOberservacao)", gettObjConnection());
                objCommand.Parameters.AddWithValue("parNome", objFamiliaresVO.gettNome());
                objCommand.Parameters.AddWithValue("parSexo", objFamiliaresVO.gettSexo());
                objCommand.Parameters.AddWithValue("parIdade", objFamiliaresVO.gettIdade());
                objCommand.Parameters.AddWithValue("parGanho_Mensal", objFamiliaresVO.gettGanhoMensal());
                objCommand.Parameters.AddWithValue("parGasto_Mensal", objFamiliaresVO.gettGastoMensal());
                objCommand.Parameters.AddWithValue("parOberservacao", objFamiliaresVO.gettObservacao());

                if (objCommand.ExecuteNonQuery() > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Falha ao Inserir ==> " + ex.Message);
            }
            finally
            {
                FechaConn();
            }
        }

        public override bool Excluir(Object objFamiliares_VO) 
        {
            try
            {
                Familiares_VO objFamiliaresVO = (Familiares_VO)objFamiliares_VO;

                AbreConn();

                objCommand = new OleDbCommand("DELETE FROM Familiares WHERE COD = :parCOD", gettObjConnection());
                objCommand.Parameters.AddWithValue("parCOD", objFamiliaresVO.gettCOD());

                if (objCommand.ExecuteNonQuery() > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Falha ao Excluir ==> " + ex.Message);
            }
            finally
            {
                FechaConn();
            }
        }

        public override bool Alterar(Object objFamiliares_VO)
        {
            try
            {
                Familiares_VO objFamiliaresVO = (Familiares_VO)objFamiliares_VO;

                AbreConn();

                objCommand = new OleDbCommand(
                    @"UPDATE Familiares SET 
                    Nome = :parNome,
                    Sexo = :parSexo,
                    Idade = :parIdade,
                    Ganho_Mensal = :parGanho_Mensal,
                    Gasto_Mensal = :parGasto_Mensal,
                    [Observação] = :parOberservacao WHERE COD = :parCOD", gettObjConnection());
                objCommand.Parameters.AddWithValue("parNome", objFamiliaresVO.gettNome());
                objCommand.Parameters.AddWithValue("parSexo", objFamiliaresVO.gettSexo());
                objCommand.Parameters.AddWithValue("parIdade", objFamiliaresVO.gettIdade());
                objCommand.Parameters.AddWithValue("parGanho_Mensal", objFamiliaresVO.gettGanhoMensal());
                objCommand.Parameters.AddWithValue("parGasto_Mensal", objFamiliaresVO.gettGastoMensal());
                objCommand.Parameters.AddWithValue("parOberservacao", objFamiliaresVO.gettObservacao());
                objCommand.Parameters.AddWithValue("parCOD", objFamiliaresVO.gettCOD());

                if (objCommand.ExecuteNonQuery() > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Falha ao Alterar ==> " + ex.Message);
            }
            finally
            {
                FechaConn();
            }
        }
    }

    public class Jogos_dos_Familiares_DAO : DAO_DAO 
    {
        public override DataTable Consultar(Object objJogos_dos_Familiares_VO) 
        {
            try
            {
                Jogos_dos_Familiares_VO objJogos_dos_FamiliaresVO = (Jogos_dos_Familiares_VO)objJogos_dos_Familiares_VO;

                AbreConn();

                if (objJogos_dos_FamiliaresVO.Jogos.gettID() <= 0)
                {
                    objCommand = new OleDbCommand(@"SELECT COD, ID, Intensidade, Observacao FROM Jogos_dos_Familiares
                                                   WHERE COD = :parCOD", gettObjConnection());
                    objCommand.Parameters.AddWithValue("parCOD", objJogos_dos_FamiliaresVO.Familiar.COD);
                }
                else
                {
                    objCommand= new OleDbCommand(@"SELECT COD, ID, Intensidade, Observacao FROM Jogos_dos_Familiares 
                                                   WHERE COD = :parCOD AND ID = :parID", gettObjConnection());
                    objCommand.Parameters.AddWithValue("parCOD", objJogos_dos_FamiliaresVO.Familiar.COD);
                    objCommand.Parameters.AddWithValue("parID", objJogos_dos_FamiliaresVO.Jogos.gettID());
                }
                objDataAdapter = new OleDbDataAdapter(objCommand);
                objTable = new DataTable();
                objDataAdapter.Fill(objTable);
                return objTable;

            }
            catch (Exception ex)
            {
                throw new Exception("Falha ao Consultar dos Jogos dos Familiares ==> " + ex.Message);
            }
            finally
            {
                FechaConn();
            }
        }

        public override List<Object> Consultar(ref Object objJogos_Familiares_VO)
        {
            try
            {
                Jogos_dos_Familiares_VO objJogos_dos_FamiliaresVO = (Jogos_dos_Familiares_VO)objJogos_Familiares_VO;

                AbreConn();

                if (objJogos_dos_FamiliaresVO.Jogos.gettID() <= 0)
                {
                    objCommand = new OleDbCommand(@"SELECT COD, ID, Intensidade, Observacao FROM Jogos_dos_Familiares
                                                   WHERE COD = :parCOD", gettObjConnection());
                    objCommand.Parameters.AddWithValue("parCOD", objJogos_dos_FamiliaresVO.Familiar.COD);
                }
                else
                {
                    objCommand = new OleDbCommand(@"SELECET COD, ID, Intensidade, Observacao FROM Jogos_dos_Familiares 
                                                   WHERE COD = :parCOD AND ID = :parID", gettObjConnection());
                    objCommand.Parameters.AddWithValue("parCOD", objJogos_dos_FamiliaresVO.Familiar.COD);
                    objCommand.Parameters.AddWithValue("parID", objJogos_dos_FamiliaresVO.Jogos.gettID());
                }
                objDataAdapter = new OleDbDataAdapter(objCommand);
                objTable = new DataTable();
                objDataAdapter.Fill(objTable);
                
                List<Object> objListaRetorno = new List<object>();

                foreach (DataRow item in objTable.Rows)
                {
                    Familiares_VO objFamiliaresVO = new Familiares_VO();
                    objFamiliaresVO.COD = Convert.ToInt32(item["COD"].ToString());
                    Object objfamilares_VO = objFamiliaresVO;
                    objFamiliaresVO = (Familiares_VO)(new Familiares_DAO()).Consultar(ref objfamilares_VO).First<Object>();

                    Jogo_VO objJogosVO = new Jogo_VO();
                    objJogosVO.settID(Convert.ToInt32(item["ID"].ToString()));
                    Object objJogos_VO = objJogosVO;
                    objJogosVO = (Jogo_VO) (new Jogos_DAO()).Consultar(ref objJogos_VO).First<Object>();

                    objJogos_dos_FamiliaresVO.Jogos_dos_Familiares_VO_Collection.Add(new Jogos_dos_Familiares_VO(objFamiliaresVO, objJogosVO,
                                                                                                              item["Intensidade"].ToString(),
                                                                                                              item["Observacao"].ToString()));
                }
                objListaRetorno.AddRange(objJogos_dos_FamiliaresVO.Jogos_dos_Familiares_VO_Collection.ToArray());
                return objListaRetorno;

            }
            catch (Exception ex)
            {
                throw new Exception("Falha ao Consultar dos Jogos dos Familiares ==> " + ex.Message);
            }
            finally
            {
                FechaConn();
            }
        }

        public override bool Inserir(Object objJogos_Familiares_VO)
        {
            try
            {
                Jogos_dos_Familiares_VO objJogos_dos_FamiliaresVO = (Jogos_dos_Familiares_VO)objJogos_Familiares_VO;

                AbreConn();

                objCommand = new OleDbCommand(
                    @"INSERT INTO Jogos_dos_Familiares(COD, ID, Intensidade, Observacao) 
                    VALUES (:parCOD,:parID,:parIntensidade,:parObservacao)", gettObjConnection());
                objCommand.Parameters.AddWithValue("parCOD", objJogos_dos_FamiliaresVO.Familiar.COD);
                objCommand.Parameters.AddWithValue("parID", objJogos_dos_FamiliaresVO.Jogos.gettID());
                objCommand.Parameters.AddWithValue("parIntensidade", objJogos_dos_FamiliaresVO.Intensidade);
                objCommand.Parameters.AddWithValue("parObservacao", objJogos_dos_FamiliaresVO.Observacao);

                if (objCommand.ExecuteNonQuery() > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Falha ao Inserir Jogos Familiares ==> " + ex.Message);
            }
            finally
            {
                FechaConn();
            }
        }

        public override bool Excluir(Object objJogos_Familiares_VO)
        {
            try
            {
                Jogos_dos_Familiares_VO objJogos_FamiliaresVO = (Jogos_dos_Familiares_VO)objJogos_Familiares_VO;

                AbreConn();

                objCommand = new OleDbCommand("DELETE FROM Jogos_dos_Familiares WHERE COD = :parCOD AND ID = :parID", gettObjConnection());
                objCommand.Parameters.AddWithValue("parCOD", objJogos_FamiliaresVO.Familiar.COD);
                objCommand.Parameters.AddWithValue("parID", objJogos_FamiliaresVO.Jogos.gettID());

                if (objCommand.ExecuteNonQuery() > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Falha ao Excluir ==> " + ex.Message);
            }
            finally
            {
                FechaConn();
            }
        }

        public override bool Alterar(Object objJogos_Familiares_VO) 
        {
            try
            {
                Jogos_dos_Familiares_VO objJogos_FamiliaresVO = (Jogos_dos_Familiares_VO)objJogos_Familiares_VO;

                AbreConn();

                objCommand = new OleDbCommand(
                    @"UPDATE Jogos_dos_Familiares SET 
                    Intensidade = :parIntensidade,
                    Observacao = :parObservacao
                    WHERE COD = :parCOD AND ID = :parID", gettObjConnection());
                objCommand.Parameters.AddWithValue("parIntensidade", objJogos_FamiliaresVO.Intensidade);
                objCommand.Parameters.AddWithValue("parObservacao", objJogos_FamiliaresVO.Observacao);
                objCommand.Parameters.AddWithValue("parCOD", objJogos_FamiliaresVO.Familiar.COD);
                objCommand.Parameters.AddWithValue("parID", objJogos_FamiliaresVO.Jogos.gettID());

                if (objCommand.ExecuteNonQuery() > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Falha ao Alterar ==> " + ex.Message);
            }
            finally
            {
                FechaConn();
            }
        }

        public void GeraExcelInterop(string strNomeDaPlanilha)
        {
            AbreConn();
            objCommand = new OleDbCommand(
                @"SELECT * INTO [Excel 8.0;DATABASE=" + strNomeDaPlanilha + "].[Excel Exporter]FROM Jogos_dos_Familiares", gettObjConnection());
            objCommand.ExecuteNonQuery();
            FechaConn();
        }
    }
}
