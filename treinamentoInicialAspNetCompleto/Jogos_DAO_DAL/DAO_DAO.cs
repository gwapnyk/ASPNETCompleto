using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;

namespace Jogos_DAO_DAL
{
    public abstract class DAO_DAO : BD_DAO_DAL
    {
        protected OleDbCommand objCommand;
        protected OleDbDataAdapter objDataAdapter;
        protected DataTable objTable;

        public abstract DataTable Consultar(Object obj_VO);
        public abstract List<Object> Consultar(ref Object obj_VO);
        public abstract bool Inserir(Object obj_VO);
        public abstract bool Excluir(Object obj_VO);
        public abstract bool Alterar(Object obj_VO);
    }
}
